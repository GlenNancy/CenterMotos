using CenterMotosApi.Models;

namespace CenterMotosApi.DTO.Builder
{
    public class MecanicoDTOBuilder
    {
        private MecanicoDTO _mecanicoDTO = new MecanicoDTO();

        public MecanicoDTOBuilder WithId(int idmecanico)
        {
            _mecanicoDTO.IdMecanico = idmecanico;
            return this;
        } 

        public MecanicoDTOBuilder WithNomeMecanico(string nomemecanico)
        {
            _mecanicoDTO.NomeMecanico = nomemecanico;
            return this;
        }

        public MecanicoDTO Build()
        {
            return _mecanicoDTO;
        }
    }
}