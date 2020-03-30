create table Compromisso(
	IdCompromisso			integer			Identity(1,1),
	Nome					nvarchar(150)	not null,
	Localidade				nvarchar(150)	not null,
	DataHora				DateTime		not null,
	Descricao				nvarchar(300)	not null,
	primary key(IdCompromisso)
)

select * from Compromisso