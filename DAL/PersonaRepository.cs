using System.Diagnostics.Contracts;
using Entity;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;


namespace DAL
{
    public class PersonaRepository
    {
        private readonly SqlConnection _connection;
        private readonly List<Persona> _personas = new List<Persona>();
        public PersonaRepository(ConnectionManager connection)
        {
            _connection = connection._conexion;
        }
         public void Guardar(Persona persona)
        {
            using (var command = _connection.CreateCommand())
            {
                command.CommandText = @"Insert Into Persona (identificacion,nombre,apellido, sexo,edad, departamento,ciudad, Valorapoyo,modalidad, fecha) 
                                        values (@identificacion,@nombre,@apellido,@sexo,@edad,@departamento,@ciudad,@Valorapoyo,@modalidad,@fecha)";
                command.Parameters.AddWithValue("@identificacion", persona.identificacion);
                command.Parameters.AddWithValue("@nombre", persona.nombre);
                command.Parameters.AddWithValue("@apellido", persona.apellido);
                command.Parameters.AddWithValue("@sexo", persona.sexo);
                command.Parameters.AddWithValue("@edad", persona.edad);
                command.Parameters.AddWithValue("@departamento", persona.departamento);
                command.Parameters.AddWithValue("@ciudad", persona.ciudad);
                command.Parameters.AddWithValue("@Valorapoyo", persona.Valorapoyo);
                command.Parameters.AddWithValue("@modalidad", persona.modalidad);
                command.Parameters.AddWithValue("@fecha", persona.fecha);
                var filas = command.ExecuteNonQuery();
            }
        }
           
            public List<Persona> ConsultarTodos()
        {
            SqlDataReader dataReader;
            List<Persona> personas = new List<Persona>();
            using (var command = _connection.CreateCommand())
            {
                command.CommandText = "Select * from persona ";
                dataReader = command.ExecuteReader();
                if (dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {
                        Persona persona = DataReaderMapToPerson(dataReader);
                        personas.Add(persona);
                    }
                }
            }
            return personas;
        }
           private Persona DataReaderMapToPerson(SqlDataReader dataReader)
        {
            if(!dataReader.HasRows) return null;
            Persona persona = new Persona();
            persona.identificacion = (string)dataReader["identificacion"];
            persona.nombre = (string)dataReader["nombre"];
            persona.apellido = (string)dataReader["apellido"];
            persona.sexo = (string)dataReader["sexo"];
           persona.edad=(int) dataReader["edad"];
             persona.departamento=(string)dataReader["departamento"];
               persona.ciudad=(string)dataReader["ciudad"];
                 persona.Valorapoyo=(int)dataReader["Valorapoyo"];
                   persona.modalidad=(string)dataReader["modalidad"];
                     persona.fecha=(string)dataReader["fecha"];
            return persona;
        }
   }
    
}
