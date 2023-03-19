# myfinance-web-netcore

MyFinance Web - Projeto de controle de finanças pessoais\
Projeto Práticas de Implementação e Evolução de Software PUC Minas

<p>
O objetivo deste projeto é possibilitar que os usuários registrem suas entradas e saídas financeiras e analisem seus gastos, a fim de que o usuário realize um planejamento financeiro mais eficaz. Essa aplicação permitirá que o usuário crie um Plano de Contas personalizado para categorizar todas as transações, e também fornecerá um relatório detalhado das transações realizadas durante um determinado período.

Tecnologias
-
O projeto manipula as seguintes tecnologias:
<ul>
  <li>ASP .NET MVC</li>
  <li>SQL Server</li>
</ul>


Banco de dados
-
No projeto, foi utilizado o banco de dados relacional SQL Server, seguindo uma modelagem de dados apresentada:

![image](https://user-images.githubusercontent.com/14062554/226212117-fc941816-e9b9-4df0-8234-efd620453a73.png)


💻 Arquitetura
-
O projeto foi dividido em etapas, seguindo as melhores práticas de arquitetura, conforme a imagem abaixo:
![image](https://user-images.githubusercontent.com/14062554/226212163-ae3d8378-12f8-4d32-93c6-571da9d54fd9.png)



Premissas
-
Até o momento, o projeto não possui uma estrutura de implantação, neste caso executamos através de uma IDE, seguindo os requisitos:

<ul>
  <li>Git</li>
  <li>VSCode</li>
  <li>.NET Core SDK</li>
  <li>SQL Server Express</li>
  <li>Criação do banco de dados através do script disponível em: 
    [myfinance_script.txt](https://github.com/ViniciusTFM/myfinance-web-netcore/files/11012411/myfinance_script.txt)
  </li>
</ul>


Execução
-
Para executar o projeto:
<ul>
  <li>Navegar até a pasta myfinance-web-netcore/src via terminal (de sua preferência)</li>
  <li>Executar o comando dotnet build</li>
  <li>Executar o comando dotnet run</li>
</ul>


Acessando a aplicação
-
<ul>
  <li>HTTPS: https://localhost:7192</li>
  <li>HTTP: http://localhost:5228</li>
</ul>


Navegação
-
<ul>
  <li>Tela de Plano de Contas</li>
</ul>
Essa tela permite criar, alterar, excluir e visualizar os planos de contas, informando uma descrição e o tipo (Receita ou Despesa):

![image](https://user-images.githubusercontent.com/14062554/226212453-adb1d872-7cdc-493b-bd30-2aace290ce38.png)

![image](https://user-images.githubusercontent.com/14062554/226213039-d655b718-439c-49cc-8a23-39f677901daa.png)

![image](https://user-images.githubusercontent.com/14062554/226213169-cafd4d55-fc59-43da-be74-35a727461c12.png)



<ul>
  <li>Tela de Transações</li>
</ul>
Por meio dessa tela, é possível criar, alterar, excluir e visualizar transações financeiras, inserindo informações como dados, valor e histórico, além de selecionar o plano de conta relacionado à transação:

![image](https://user-images.githubusercontent.com/14062554/226212525-de0d4ef2-ec56-4f09-a68c-0499682f7f40.png)

![image](https://user-images.githubusercontent.com/14062554/226213048-6ed7bc0c-c883-4746-90c3-65231e6e52da.png)

![image](https://user-images.githubusercontent.com/14062554/226213121-012fa454-2c21-4dc0-9941-61905ade7996.png)




</p>
