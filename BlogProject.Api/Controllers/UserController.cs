﻿using AutoMapper;
using BlogProject.Api.Validation.FluentValidation;
using BlogProject.Business.Abstract;
using BlogProject.Entity.DTO.Category;
using BlogProject.Entity.DTO.User;
using BlogProject.Entity.Poco;
using BlogProject.Entity.Result;
using BlogProject.Helper.CustomException;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace BlogProject.Api.Controllers
{
    [ApiController]
    [Route("[action]")]
    public class UserController : Controller
    {

        private readonly IUserServise _userService;
        private readonly IMapper _mapper;

        public UserController(IUserServise userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        [HttpGet("/Users")]
        [ProducesResponseType(typeof(Sonuc<List<UserResponseDTO>>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetUsers()
        {
            var users = await _userService.GetAllAsync();
            List<UserResponseDTO> userDTOList = new();

            foreach (var user in users) 
            {
                userDTOList.Add(_mapper.Map<UserResponseDTO>(user));
                
            }
            return Ok(Sonuc<List<UserResponseDTO>>.SuccussWithData(userDTOList));
        }


        [HttpGet("/User/{id}")]
        [ProducesResponseType(typeof(Sonuc<UserResponseDTO>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetUser(int id)
        {
            var user = await _userService.GetAsync(q=>q.id==id);

            if(user!=null)
            {
                UserResponseDTO userDTO = _mapper.Map<UserResponseDTO>(user);


                return Ok(Sonuc<UserResponseDTO>.SuccussWithData(userDTO));
            }

            return NotFound(Sonuc<UserResponseDTO>.SuccussNoDataFound());
        }


        //Data Transfer Object
        [HttpPost("/AddUser")]
        [ProducesResponseType(typeof(Sonuc<UserResponseDTO>),(int)HttpStatusCode.OK)]
        public async Task<IActionResult> AddUser(UserRequestDTO userRequestDTO)
        {
            UserRegisterValidation userRegisterValidation = new UserRegisterValidation();

            if (userRegisterValidation.Validate(userRequestDTO).IsValid)
            {
                User user = _mapper.Map<User>(userRequestDTO);
                await _userService.AddAsync(user);
                UserResponseDTO userResponseDTO = _mapper.Map<UserResponseDTO>(user); 
                return Ok(Sonuc<UserResponseDTO>.SuccussWithData(userResponseDTO));
            }
            else
            {
                List<string> ValidatorMessage = new List<string>();
                for (int i = 0; i < userRegisterValidation.Validate(userRequestDTO).Errors.Count; i++)
                {
                    ValidatorMessage.Add(userRegisterValidation.Validate(userRequestDTO).Errors[i].ErrorMessage);

                }
                throw new FieldValidationException(ValidatorMessage);
            }
        }
    }
}
