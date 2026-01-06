using System.Security.Cryptography;
using System.Text;
using API.Data;
using API.DTOs;
using API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API.Services;

namespace API.Controllers;

public class AccountController : BaseApiController
{
    private readonly DataContext _context;
    private readonly ITokenService _tokenService;

    public AccountController(DataContext context, ITokenService tokenService)
    {
        _context = context;
        _tokenService = tokenService;
    }

    // POST api/account/register
    [HttpPost("register")]
    public async Task<ActionResult<UserDto>> Register(RegisterDto registerDto)
    {
       

        if (await _context.Users.AnyAsync(x =>  x.Email == registerDto.Email))
        {
            return BadRequest("Email is already taken.");
        }

        using var hmac = new HMACSHA512();

        var user = new appUser
        {
            UserName = registerDto.Username,
            Email = registerDto.Email,
            PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(registerDto.Password)),
            PasswordSalt = hmac.Key
        };

        _context.Users.Add(user);
        await _context.SaveChangesAsync();

            var userDto = new UserDto{
            Username = user.UserName,
            Email = user.Email,
            Token = _tokenService.CreateToken(user)
        };
        return Ok(userDto);

    
    }

    [HttpPost("login")]
    public async Task<ActionResult<appUser>> Login(LoginDto loginDto)
    {
        var user = await _context.Users.FirstOrDefaultAsync(x => x.Email == loginDto.Email.ToLower());

        if (user == null) return Unauthorized("Invalid email or password");

        using var hmac = new HMACSHA512(user.PasswordSalt);
        var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(loginDto.Password));
        for (int i = 0; i < computedHash.Length; i++)
        {
            if (computedHash[i] != user.PasswordHash[i]) return Unauthorized("Invalid emailaa or password");
        }
        
        var userDto = new UserDto{
            Username = user.UserName,
            Email = user.Email,
            Token = _tokenService.CreateToken(user)
        };
        return Ok(userDto);
    }
}