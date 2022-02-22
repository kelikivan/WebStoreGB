using Microsoft.AspNetCore.Mvc.ApplicationModels;

namespace WebStore.Infrastructure.Conventions
{
	public class TextConvention : IControllerModelConvention
	{
		public void Apply(ControllerModel controller)
		{
			//Debug.WriteLine(controller.ControllerName);
		}
	}
}
