
using AutoMapper;
using CoronaApp.Entities;
using CoronaApp.Services.Models;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using RabbitMQ.Client;
using Serilog;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace CoronaApp.Services
{
    public class PatientService : IPatientService
    {
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;
        private IPatientRepository _patientRepository;
        public PatientService(IPatientRepository patientRepository, IMapper mapper, LinkGenerator linkGenerator, IConfiguration configuration )
        {
            _patientRepository = patientRepository;
            _mapper = mapper;
            _configuration = configuration;

        }

        public async Task<PatientModel> GetById(int id)
        {


            Patient patient = await _patientRepository.GetById(id);
            if (patient == null)
            {
                return null;
            }

            return _mapper.Map<PatientModel>(patient);
        }

        public async Task<List<PatientModel>> GetPatientsByAge(int age)
        {
          List<Patient> patients = await _patientRepository.GetPatientsByAge(age);
            return _mapper.Map<List<PatientModel>>(patients);
        }

        public async Task<PatientModel> Save(PatientModel newPatient)
        {
            Patient patient = await _patientRepository.GetById(newPatient.PatientId);

            if (patient != null)
            {
                return null;
            }

            patient = _mapper.Map<Patient>(newPatient);
            Patient newPatientFromDbs = await _patientRepository.Save(patient);
            Log.Information("Patient Created {@newPatient}", newPatient);

            SendToConsumers($"Patient Created with id: {newPatientFromDbs.PatientId}", "info");
            return _mapper.Map<PatientModel>(newPatientFromDbs);
        }

        public async Task<PatientModel> Update(PatientModel updatedPatient)
        {
            Patient patient = await _patientRepository.GetById(updatedPatient.PatientId);
            if (patient == null)
            {
                return null;
            }
            patient = _mapper.Map<Patient>(updatedPatient);

            Patient updatedPatientFromDbs = await _patientRepository.Update(patient);
            Log.Information("Patient with id {@id} updated {@newPatient}", updatedPatientFromDbs.PatientId, updatedPatientFromDbs);
            return _mapper.Map<PatientModel>(updatedPatientFromDbs);

        }

        public async Task<string> AuthenticateAsync(string username, string password)
        {
           // Patient patient = new Patient { Age = 1, Password = "1" };
            Patient patient =await _patientRepository.getByUserNameAndPassword(username ,password);

            // return null if user not found
            if (patient == null)
                return null;


            // authentication successful so generate jwt token
            var tokenHandler = new JwtSecurityTokenHandler();

            var key = Encoding.ASCII.GetBytes(_configuration.GetValue<string>("AppSettings:Secret"));
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, patient.UserName.ToString())
                }),
                Expires = DateTime.UtcNow.AddMinutes(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
           var stringToken = tokenHandler.WriteToken(token);

            return stringToken;
       
        }

        public async Task<string> GetUserName(int id)
        {
            string patientName = await _patientRepository.GetUserName(id);
            return patientName;

        }

        //ActionResult delete(int id)
        //{
        //    return _patientRepository.Delete(id);
        //}


        public void SendToConsumers(string message, string routingKey)
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };
            using (var connection = factory.CreateConnection())
            {
                using (var channel = connection.CreateModel())
                {
                    //channel.ConfirmSelect();

                    channel.ExchangeDeclare(exchange: "direct_logs",
                                    type: ExchangeType.Direct);

                   
                  
                    var body = Encoding.UTF8.GetBytes(message);

                    channel.BasicPublish(exchange: "direct_logs",
                                         routingKey: routingKey,
                                         basicProperties: null,
                                         body: body);

                    //channel.WaitForConfirmsOrDie(new TimeSpan(0, 0, 5));

    

                }
  
            }

        }

        private static string GetMessage(string[] args)
        {
            return ((args.Length > 0) ? string.Join(" ", args) : "Hello World!");
        }
    }
}


