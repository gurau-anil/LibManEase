﻿using AutoMapper;
using LibManEase.Application.Abstraction.Contracts.Logging;
using LibManEase.Application.Abstraction.Contracts.Services;
using LibManEase.Application.Abstraction.DTOs;
using LibManEase.Domain.Contracts.Base;
using LibManEase.Domain.Entities.Base;


namespace LibManEase.Application.Implementation.Services
{
    internal class GenericService<TEntity, TDto, TCreateDto, TUpdateDto> : IGenericService<TDto, TCreateDto, TUpdateDto>
        where TEntity : BaseEntity<int>
        where TDto : BaseDto
        where TCreateDto : class
        where TUpdateDto : BaseDto
    {
        protected readonly IRepository<TEntity, int> _repository;
        protected readonly IMapper _mapper;
        protected readonly IAppLogger _logger;

        public GenericService(IRepository<TEntity, int> repository, IMapper mapper, IAppLogger logger)
        {
            _repository = repository;
            _mapper = mapper;
            _logger = logger;
        }

        public virtual async Task<TDto> GetByIdAsync(int id)
        {
            var entity = await _repository.GetByIdAsync(id);
            return _mapper.Map<TDto>(entity);
        }

        public virtual async Task<IEnumerable<TDto>> GetAllAsync()
        {
            _logger.LogInformation($"Fetching {typeof(TDto).Name}");
            var entities = await _repository.GetAllAsync();
            _logger.LogInformation($"Fetching {typeof(TDto).Name} completed");
            return _mapper.Map<IEnumerable<TDto>>(entities);
        }

        public virtual async Task<TDto> CreateAsync(TCreateDto createDto)
        {
            var entity = _mapper.Map<TEntity>(createDto);
            var createdEntity = await _repository.AddAsync(entity);
            return _mapper.Map<TDto>(createdEntity);
        }

        public virtual async Task UpdateAsync(TUpdateDto updateDto)
        {
            var entity = await _repository.GetByIdAsync(updateDto.Id);
            if (entity == null)
                throw new KeyNotFoundException($"Entity with id {updateDto.Id} not found.");

            _mapper.Map(updateDto, entity);
            await _repository.UpdateAsync(entity);
        }

        public virtual async Task DeleteAsync(int id)
        {
            var entity = await _repository.GetByIdAsync(id);
            if (entity == null)
                throw new KeyNotFoundException($"Entity with id {id} not found.");

            await _repository.DeleteAsync(entity);
        }
    }
}
