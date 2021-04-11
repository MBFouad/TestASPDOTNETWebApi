using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
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

        private IUnitOfWork _unitofwork;

        public UserController(IUserRepo repository, IMapper mapper,IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _mapper = mapper;
            _unitofwork = unitOfWork;

        }

        [HttpGet]
        public ActionResult<IEnumerable<UserReadDto>> GetAllUsers()
        {
           var usersList = _repository.GetAllUsers();
            var userByUnit = _unitofwork.UserRepo.GetAllUsers();
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
        //PATCH api/user/{id}

        [HttpPatch("{id}")]
        public ActionResult PartialUserUpdate(int id, JsonPatchDocument<UserUpdateDto> patchDoc)
        {
            var commandModelFromRepo = _repository.GetAllUserById(id);
            if (commandModelFromRepo == null)
            {
                return NotFound();
            }
            var userToPatch = _mapper.Map<UserUpdateDto>(commandModelFromRepo);
            patchDoc.ApplyTo(userToPatch, ModelState);
            if (!TryValidateModel(userToPatch)) {
                return ValidationProblem(ModelState);
            }
            _mapper.Map(userToPatch, commandModelFromRepo);
            _repository.UpdateUser(commandModelFromRepo);
            _repository.saveChnages();
            return NoContent();


        }

        //DELETE api/user/{id}
        [HttpDelete("{id}")]
        public ActionResult DeleteUser(int id)
        {
            var commandModelFromRepo = _repository.GetAllUserById(id);
            if (commandModelFromRepo == null)
            {
                return NotFound();
            }
            _repository.DeleteUser(commandModelFromRepo);
            _repository.saveChnages();
            return NoContent();
        }

    
    }
}
