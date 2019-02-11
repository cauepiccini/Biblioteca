CREATE DATABASE bd_biblioteca;


USE bd_biblioteca;


CREATE TABLE `tb_aluno`(
	`alu_cod` int(11) NOT NULL PRIMARY KEY auto_increment,
    `alu_nome` varchar(45) NOT NULL,
    `alu_turma` varchar(10) NOT NULL,
    `alu_contato` varchar(10) NOT NULL,
    `alu_data_nascimento` varchar(11) NOT NULL
)engine=innodb default charset=utf8;


CREATE TABLE `tb_livro`(
	`liv_cod` int(11) NOT NULL PRIMARY KEY auto_increment,
    `liv_nome` varchar(45) NOT NULL,
    `liv_tema` varchar(40) NOT NULL,
    `liv_autor` varchar(45) NOT NULL,
    `liv_editora` varchar(45) NOT NULL,
    `liv_quanti` int(5) NOT NULL
)engine=innodb default charset=utf8;


CREATE TABLE `tb_emprestimo`(
	`emp_cod` int(11) NOT NULL PRIMARY KEY,
	`emp_nomealu` varchar(45) NOT NULL,
    `emp_nomeliv` varchar(45) NOT NULL,
    `emp_data_retira` varchar(11) NOT NULL,
    `emp_data_devol` varchar(11) NOT NULL
)engine=innodb default charset=utf8;