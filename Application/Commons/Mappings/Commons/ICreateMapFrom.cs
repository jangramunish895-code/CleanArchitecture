using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Commons.Mappings.Commons;

public interface ICreateMapFrom<T>
{
    void CreateMapping(Profile profile)=>profile.CreateMap(this.GetType(), typeof(T))
        .ForAllMembers(opt=>opt.Condition((src, dest, srcMember) => srcMember != null));
}
