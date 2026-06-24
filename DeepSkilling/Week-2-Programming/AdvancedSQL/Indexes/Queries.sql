USE CTSDB;

CREATE VIEW EmpView AS SELECT Id,Name,Dept FROM Employee;

SELECT * FROM EmpView;

CREATE INDEX idx_name ON Employee(Name);

SELECT * FROM Employee WHERE Name='Ram';