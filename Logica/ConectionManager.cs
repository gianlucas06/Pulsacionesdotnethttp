using System;

namespace Logica
{
    public class ConectionManager
    {
        internal SqlConnection _conexion;
    
    private readonly ConnectionManager _conexion;
    private readonly PersonaRepository _repositorio;

    public PersonaService(string connectionString)
    {
        _conexion = new ConnectionManager(connectionString);
        _repositorio = new PersonaRepository (_conexion);
    }
     public GuardarPersonaResponse Guardar(Persona persona) {            
         try {persona.CalcularPulsaciones(); 
          _conexion.Open();               
           _repositorio.Guardar(persona);                
           _conexion.Close();                
           return new GuardarPersonaResponse(persona);           
           }            
           catch (Exception e)            
           {                
               return new GuardarPersonaResponse($"Error de la Aplicacion: {e.Message}");            
               }            
               finally { _conexion.Close(); }        
      }
    }
}
