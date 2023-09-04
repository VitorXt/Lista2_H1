# Dev_Web_Lista02
Lista 2 de atividade de Desenvolvimento Web - 4° Período Uniaraxá

<div>
    <h1>Lista 2 de atividades:</h1>
    <h3>Questão 1: Descreva 3 importantes motivos para validarmos os dados em nossa API.</h3>
      <p>1 - Integridade de dados - A validação dos dados ajuda a garantir que apenas informações válidas e corretas sejam aceitas e processadas pela API. Isso evita que dados incorretos, mal formatados ou maliciosos causem erros nos sistemas ou afetem os resultados das operações.</p>
      <p>2 - Eficiencia - A validação de dados evita a ocorrência de erros ou exceções durante a execução das operações da API. Isso reduz a carga de trabalho desnecessária nos servidores e minimiza o tempo gasto na resolução de erros. Além disso, ao rejeitar dados inválidos o mais cedo possível, você pode evitar processamentos desnecessários.</p>  
      <p>3 - Melhor experiencia do usuario - Dados válidos e bem formatados garantem que os usuários da API possam interagir de maneira mais eficaz e sem interrupções. Quando os dados são validados e mensagens de erro claras são fornecidas, os usuários podem corrigir erros facilmente, melhorando sua experiência geral.</p> 
  <br>
  <br>
    <h3>Questão 2: Considere as seguintes entidades, descreva quais as validações você faria e como faria:</h3>
      <h4>a)	Cenário 1: Cadastro de cliente com: </h4>
	  <p>A - Nome: validação de tamanho de string e obrigatório. Utilizaria o data annotation</p>
	  <p>B - CPF: validação da receita e obrigatório. Utilizaria um data annotation personalizado</p>
	  <p>C - Data Nascimento: validação que verifica idade. Utilizaria o data annotation</p>
	  <p>D - Email: validação de formato e verificar se é único. Utilizaria o data annotation</p>
	  <p>E - Telefone: validação de formato e verificar se é único. Utilizaria o data annotation</p>
	  <p>F - Senha: validação para que a senha contenha alguns critérios.</p>
	  <p>G - Cep, Rua, Bairro, Cidade, Estado: verificação de formato e se o lugar existe.</p>
      <h4>b)	Cenário 2: Cadastro de Disciplina</h4>
            <p>A - Nome: validação de tamanho de string e obrigatório. Utilizaria o data annotation</p>
	    <p>B - Carga horária: validação de tipo. Utilizaria o data annotation</p>
	    <p>C - Objetivo: validação de tamanho de string. Utilizaria o data annotation</p>
	    <p>D - Ementa: validação de tamanho de string. Utilizaria o data annotation</p>
	    <p>E - Semestre: validação para verificar se está dentro de uma faixa válida</p>
	    <p>F - Ano: validação de tipo. Utilizaria o data annotation</p>
	    <p>G - Nome professor: validação de tamanho de string e obrigatório. Utilizaria o data annotation</p>
  <br>
  <br>
    <h3>Questão 3: Em sala mostramos as validações utilizando inicialmente “o bom e velho if/else”, porém falamos que esse processo pode conter vantagens e desvantagens, por isso, mostramos depois o data annotation. Descreva comparando as duas técnicas apresentando vantagens e desvantagens.</h3>
	
<h4>If/Else:</h4>

<p>Vantagens: Controle total, flexibilidade e compatibilidade universal.</p>
<p>Desvantagens: Código verboso, dificuldade de leitura e manutenção complexa.</p>

<h4>Data Annotation:</h4>

<p>Vantagens: Desacoplamento, legibilidade e facilidade de manutenção.</p>
<p>Desvantagens: Limitado em complexidade, dependência de frameworks e menos controle.</p>
  <br>
  <br>
    <h3>Questão 4: Em sala mostramos que ao usar o data annotation, quando um dado é invalidado, ele não “chamava” a action e já retornava o “error message”. Descreva o que acontecia nesse caso que ele automaticamente já validava e não caia no debug da action?</h3>
      <p>Ao usar data annotation para validações em uma aplicação, se os dados de entrada não atenderem às regras de validação definidas, o framework interrompe a execução da action e retorna um "error message" automaticamente, sem entrar no ponto de depuração da action. Isso ocorre porque o framework detecta a invalidade dos dados antes de executar o código da action, economizando recursos e melhorando a eficiência e a segurança da aplicação. </p>
  <br>
  <br>
    <h3>Questão 5: Crie no AlunoController que você criou na lista anterior de exercícios as validações para a classe aluno (Nome, Ra, Email, Cpf, Ativo).
Obs: Crie uma validação customizada com as seguintes regras
</h3>
      <p>•	Começa com as letras RA</p>
      <p>•	Após o RA números de tamanho 6 dígitos, sendo cada dígito variando de 0 à 9</p>
</div>
