using IGNITE.Web.API.Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IGNITE.Core.Domain.User;
using AutoMapper;

namespace IGNITE.Web.API
{
    public static class MappingExtensions
    {
        #region User
        public static UserModel ToModel(this User model)
        {
            Mapper.CreateMap<User, UserModel>()
                 .ForMember(ev => ev.Id, m => m.MapFrom(a => a.Id))
                .ForMember(ev => ev.FirstName, m => m.MapFrom(a => a.FirstName))
                .ForMember(ev => ev.LastName, m => m.MapFrom(a => a.LastName))
                .ForMember(ev => ev.Username, m => m.MapFrom(a => a.Username))
                .ForMember(ev => ev.Password, m => m.MapFrom(a => a.Password))
                .ForMember(ev => ev.PhoneNumber, m => m.MapFrom(a => a.PhoneNumber))
                .ForMember(ev => ev.Status, m => m.MapFrom(a => a.Status))
                .ForMember(ev => ev.StatusMessage, m => m.MapFrom(a => a.StatusMessage))
                .ForMember(ev => ev.Image, m => m.MapFrom(a => a.Image))
                .ForMember(ev => ev.LastLoggedIN, m => m.MapFrom(a => a.LastLoggedIN))
                .ForMember(ev => ev.TcAcceptedDate, m => m.MapFrom(a => a.TcAcceptedDate))
                .ForMember(ev => ev.DateOfBirth, m => m.MapFrom(a => a.DateOfBirth));
            return Mapper.Map<User, UserModel>(model);
        }

        public static User ToEntity(this UserModel model)
        {
            Mapper.CreateMap<UserModel, User> ()
                 .ForMember(ev => ev.Id, m => m.MapFrom(a => a.Id))
                .ForMember(ev => ev.FirstName, m => m.MapFrom(a => a.FirstName))
                .ForMember(ev => ev.LastName, m => m.MapFrom(a => a.LastName))
                .ForMember(ev => ev.Username, m => m.MapFrom(a => a.Username))
                .ForMember(ev => ev.Password, m => m.MapFrom(a => a.Password))
                .ForMember(ev => ev.PhoneNumber, m => m.MapFrom(a => a.PhoneNumber))
                .ForMember(ev => ev.Status, m => m.MapFrom(a => a.Status))
                .ForMember(ev => ev.StatusMessage, m => m.MapFrom(a => a.StatusMessage))
                .ForMember(ev => ev.Image, m => m.MapFrom(a => a.Image))
                .ForMember(ev => ev.LastLoggedIN, m => m.MapFrom(a => a.LastLoggedIN))
                .ForMember(ev => ev.TcAcceptedDate, m => m.MapFrom(a => a.TcAcceptedDate))
                .ForMember(ev => ev.DateOfBirth, m => m.MapFrom(a => a.DateOfBirth));
            return Mapper.Map<UserModel, User>(model);
        }
        #endregion
    }
}