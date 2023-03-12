Create TABle Clients (
id INT NOT NULL PRIMARY KEY IDENTITY,
name VARCHAR (100) NOT NULL,
surname VARCHAR (100) NOT NULL,
secondname VARCHAR (100) NOT NUll,
email VARCHAR (150) NOT NULL  UNIQUE,
phone VARCHAR (20) Null,
birthday DATE,
Created_at DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP
);
INSERT INTO Clients (name, surname, secondname, email, phone, birthday)
VALUES
('Александр','Журавский','Сергеевич','Zuravskiy228@mail.ru','+375291234567','2023-01-08')