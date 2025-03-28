﻿using LibManEase.Application.Abstraction.DTOs;

namespace LibManEase.Application.Abstraction.Contracts.Services
{
    public interface IGenericService<TDto, TCreateDto, TUpdateDto>
    where TDto : BaseDto
    where TCreateDto : class
    where TUpdateDto : BaseDto
    {
        Task<TDto> GetByIdAsync(int id);
        Task<IEnumerable<TDto>> GetAllAsync();
        Task<TDto> CreateAsync(TCreateDto createDto);
        Task UpdateAsync(TUpdateDto updateDto);
        Task DeleteAsync(int id);
    }
}
