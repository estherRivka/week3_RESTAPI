
using AutoMapper;
using CoronaApp.Entities;
using CoronaApp.Services.Models;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Serilog;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace CoronaApp.Services
{
    public class PatientService : IPatientService
    {
        private readonly IMapper _mapper;
        private IPatientRepository _patientRepository;
        private IConfiguration _configuration;
        public PatientService(IConfiguration configuration, IPatientRepository patientRepository, IMapper mapper, LinkGenerator linkGenerator )
        {
            _configuration = configuration;
            _patientRepository = patientRepository;
            _mapper = mapper;
        }

        public async Task<PatientModel> Authenticate(string username, string password)
        {
            Patient user = await _patientRepository.GetByUserNameAndPassword(username,password);

            // return null if user not found
            if (user == null)
                return null;

            // authentication successful so generate jwt token
            var tokenHandler = new JwtSecurityTokenHandler();
            
            //  _configuration.GetValue<string>("AppSettings:secret");
            var key = Encoding.ASCII.GetBytes(_configuration.GetValue<string>("AppSettings:Secret"));
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.UserName.ToString())
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            user.Token = tokenHandler.WriteToken(token);
            return _mapper.Map<PatientModel>(user);
          //  return user;
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

        //ActionResult delete(int id)
        //{
        //    return _patientRepository.Delete(id);
        //}
    }
}

