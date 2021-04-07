using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Test_ASP_Core_Web_Api__1_.Data;
using Test_ASP_Core_Web_Api__1_.Dtos;
using Test_ASP_Core_Web_Api__1_.Models;

namespace Test_ASP_Core_Web_Api__1_.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IUserRepo _repository;
        private IMapper _mapper;

        public UserController(IUserRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;

        }

        [HttpGet]
        public ActionResult<IEnumerable<UserReadDto>> GetAllUsers()
        {
            var usersList = _repository.GetAllUsers();
            return Ok(_mapper.Map<IEnumerable<UserReadDto>>(usersList));

        }

        [HttpGet(Name = "GetUserById")]
        public ActionResult<UserReadDto> GetUserById(int id)
        {
            var user = _repository.GetAllUserById(id);
            if (user != null)
            {
                return Ok(_mapper.Map<UserReadDto>(user));
            }

            return NotFound();


        }

        [HttpPost]
        public ActionResult<UserReadDto> CreateUser(UserCreateDto user)
        {
            var userModel = _mapper.Map<User>(user);
            _repository.CreateUser(userModel);
            _repository.saveChnages();
            var userReadDto = _mapper.Map<UserReadDto>(userModel);

            return CreatedAtRoute(nameof(GetUserById), new { Id = userReadDto.Id }, userReadDto);

            //return Ok(_mapper.Map<UserReadDto>(userModel));

        }

        [HttpPut]
        public ActionResult UpdateUser(int id, UserUpdateDto userUpdateDto) {

            var userModelFromRepo = _repository.GetAllUserById(id);
            //error 404
            if (userModelFromRepo == null) {
                return NotFound();
            }

            _mapper.Map(userUpdateDto, userModelFromRepo);

            _repository.UpdateUser(userModelFromRepo);
            _repository.saveChnages();

            return NoContent();
        }
    }
}
