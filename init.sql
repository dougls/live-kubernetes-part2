CREATE TABLE products (
    id SERIAL PRIMARY KEY,
    name TEXT NOT NULL
);
INSERT INTO products(name) VALUES ('Notebook'), ('Mouse'), ('Teclado');
CREATE TABLE orders (
    id SERIAL PRIMARY KEY,
    product_id INT REFERENCES products(id),
    quantity INT NOT NULL
);
INSERT INTO orders(product_id, quantity) VALUES (1, 2), (2, 5);