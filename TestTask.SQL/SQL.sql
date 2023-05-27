/* INIT */
/* Делал в SQLite, могут быть небольшие отличия от SQLServer'a */

CREATE TABLE IF NOT EXISTS  Product(
                                       Id INT NOT NULL PRIMARY KEY,
                                       Name VARCHAR(255) NOT NULL
    );

CREATE TABLE IF NOT EXISTS  Category(
                                        Id INT NOT NULL PRIMARY KEY,
                                        Name VARCHAR(255) NOT NULL
    );

CREATE TABLE IF NOT EXISTS ProductCategory(
                                              Id INT NOT NULL PRIMARY KEY,
                                              ProductId INT NOT NULL REFERENCES Product(Id),
    CategoryId INT NOT NULL REFERENCES Category(Id)
    );

INSERT INTO Product
VALUES
    (1, 'Product 1'),
    (2, 'Product 2'),
    (3, 'Product 3'),
    (4, 'Product 4');

INSERT INTO Category
VALUES
    (1, 'Books'),
    (2, 'Eat'),
    (3, 'Phone');

INSERT INTO ProductCategory
VALUES
    (1, 1, 1),
    (2, 2, 1),
    (3, 3, 2),
    (4, 3, 1);

SELECT Product.Name, Category.Name
FROM Product
         LEFT JOIN ProductCategory
                   ON Product.Id = ProductCategory.ProductId
         LEFT JOIN Category
                   ON ProductCategory.CategoryId = Category.Id;

DROP TABLE Category;
DROP TABLE ProductCategory;
DROP TABLE Product;