using ProjetoDDD.Domain.Entities;
using System.Data.Entity.ModelConfiguration;


namespace ProjetoDDD.Infra.Data.EntityConfig
{
    public class ClienteConfiguration : EntityTypeConfiguration<Cliente>
    {
        public ClienteConfiguration()
        {
            HasKey(c => c.ClienteId);

            Property(c => c.Nome)
                .IsRequired()
                .HasMaxLength(200);

            Property(c => c.Cpf)
                .IsRequired();

            Property(c => c.DataCadastro)
                .IsRequired();
        }
    }
}
