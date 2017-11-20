using System.Web.Mvc;
using Microsoft.Practices.Unity;
using Unity.Mvc4;
using FamilyTree.DAL.Interfaces;
using FamilyTree.DAL.Repositories;
using FamilyTree.BLL;
using FamilyTree.BLL.Managers;
using FamilyTree.Presentation.Models.ViewModelRepository;

namespace FamilyTree.Presentation
{
  public static class Bootstrapper
  {
    public static IUnityContainer Initialise()
    {
      var container = BuildUnityContainer();

      DependencyResolver.SetResolver(new UnityDependencyResolver(container));

      return container;
    }

    private static IUnityContainer BuildUnityContainer()
    {
      var container = new UnityContainer();

      // register all your components with the container here
      // it is NOT necessary to register your controllers

      // e.g. container.RegisterType<ITestService, TestService>();   
      container.RegisterType<IPersonRepository, PersonRepository>();
      container.RegisterType<FamilyManager>();
      container.RegisterType<ViewModelManager>();
      container.RegisterType<DALModelRetriever>();
      container.RegisterType<DALModelModifier>();
     
      RegisterTypes(container);

      return container;
    }

    public static void RegisterTypes(IUnityContainer container)
    {
    
    }
  }
}