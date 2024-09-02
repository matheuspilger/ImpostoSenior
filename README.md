
# Imposto Senior

Essa API tem como objetivo importar arquivos, processar cálculos e exportar relatórios referente a Escrituração Contábil Digital(ECD).

Para o projeto foi utilizado as seguintes itens:

- .NET 8.0
- MongoDB
- Mediator
- DDD (Domain-driven design)
- Design Patterns (Repository, Factory, Strategy)
- Clean Code

Com base nisso foi desenvolvido uma aplicação no modelo de API para realizar as devidas operações solicitadas na documentação da avaliação (TAX STRATEGY DESENVOLVIMENTO BACKEND).

Para acesso a API temos o seguinte endpoint:

- Endpoint da Aplicação: https://localhost:7267/swagger/index.html

Para rodar a aplicação é necessário rodar a mesma localmente no seu computador, e instalar o MongoDB para persistência e consulta dos dados.

- Link do MongoDB: https://www.mongodb.com/try/download/community
- Link .NET: https://dotnet.microsoft.com/pt-br/download/dotnet/8.0

Implementações Futuras:
- Rodar aplicação no Docker
- Implementar Teste Unitários e de Integração
- Outras melhorias

Observação:
- Como o arquivo estava incompleto, faltando os primeiros blocos, para identificar os dados da empresa, utilizei o registro C040 pra realizar controles internos.
## Documentação da API

#### Importar arquivo txt da Escrituração Contábil Digital(ECD) e persistir no banco de dados MongoDB.

```https
  POST /ImportarEcd
```

| Parâmetro   | Tipo       |
| :---------- | :--------- |
| `Dto.FilePath` | `ImportarDto`|

#### Processar o cáculo de imposto referente aos registros da Escrituração Contábil Digital(ECD).

```https
  POST /CalcularImpostoEcd
```

| Parâmetro   | Tipo       |
| :---------- | :--------- |
| `Dto.DataInicial, Dto.DataFinal, Dto.Cnpj, Dto.Hash` | `FiltroImpostoEcdDto` |

#### Gerar relatório dos registros da Escrituração Contábil Digital(ECD) com imposto cálculado exportando o mesmo em Excel.

```https
  POST /ExportarRelatorioImpostoEcd
```

| Parâmetro   | Tipo       |
| :---------- | :--------- |
| `Dto.DataInicial, Dto.DataFinal, Dto.Cnpj, Dto.Hash` | `FiltroImpostoEcdDto` |
