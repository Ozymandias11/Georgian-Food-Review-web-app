﻿using AutoMapper;
using Contracts;
using Entities.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Service.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class ServiceManager : IServiceManager
    {
        private readonly Lazy<ICategoryService> _categoryService;
        private readonly Lazy<ICountryService> _countryService;
        private readonly Lazy<IFoodService> _foodService;
        private readonly Lazy<IReviewerService> _reviewerService;
        private readonly Lazy<IReviewService> _reviewService;
        private readonly Lazy<IAuthenticationService> _authenticationService;

        public ServiceManager(IRepositoryManager repositoryManager, ILoggerManager loggerManager,
            IMapper mapper, ValidationService validationService, UserManager<User> usermanager, IConfiguration configuration)
        {
            _categoryService = new Lazy<ICategoryService>(() => new CategoryService(repositoryManager, loggerManager, mapper, validationService));
            _countryService = new Lazy<ICountryService>(() => new CountryService(repositoryManager, loggerManager, mapper, validationService));
            _foodService = new Lazy<IFoodService>(() => new FoodService(repositoryManager, loggerManager, mapper, validationService));
            _reviewerService = new Lazy<IReviewerService>(() => new ReviewerService(repositoryManager, loggerManager, mapper, validationService));
            _reviewService = new Lazy<IReviewService>(() => new ReviewService(repositoryManager, loggerManager, mapper, validationService));
            _authenticationService = new Lazy<IAuthenticationService>(() => new AuthenticationService(loggerManager, mapper,usermanager, configuration));
        }

        public ICategoryService CategoryService => _categoryService.Value;

        public ICountryService CountryService => _countryService.Value;

        public IFoodService FoodService => _foodService.Value;

        public IReviewerService ReviewerService => _reviewerService.Value;

        public IReviewService ReviewService => _reviewService.Value;

        public IAuthenticationService AuthenticationService => _authenticationService.Value;
    }
}
