using System;

namespace MuonLab.Web.Xhtml.Components
{
    public interface IFormattableComponent : IVisibleComponent
    {
    }

    public interface IFormattableComponent<TProperty> : IVisibleComponent<TProperty>, IFormattableComponent
    {
    }
}