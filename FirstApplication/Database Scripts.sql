create database storeProduction;
use storeProduction
create table useraccounts(userID varchar(50), userName varchar(50), userPassword varchar(50), userType varchar(50), accountDate date, primary key(userID))
create table products(productID varchar(50), productName varchar(50), productPic varbinary(MAX), productDescription varchar(255), productCategoryA varchar(50), productCategoryB varchar(50), productCategoryC varchar(50), productPrice float(24), productQuantity int, productDate date, userID varchar(50), primary key(productID), foreign key(userID) references useraccounts(userID)  )
create table tags(tagID varchar(50), tagName varchar(50), tagDescription varchar(255),userID varchar(50), primary key(tagID), foreign key(userID) references useraccounts(userID))
create table usertransaction(transactionID varchar(50), productID varchar(50), transactionQuantity int, transactionPrice float(24), userID varchar(50))
create table usertransactiondetails(transactionID varchar(50), userID varchar(50), transactionCash float(24), transactionChange float(24))

insert into useraccounts values('ACCOUNT00001','Admin','Admin','Administrator','2019-2-22')

select * from useraccounts