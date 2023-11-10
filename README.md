
# PeriféricosFGH

## About this Project:

The idea of this project is build an Api REST for a peripherals store.

## Why?

I wanted to create a new project with .Net 7 using good practices and based on the DDD (Domain Driven Design) architecture, so I simulated a project for a virtual peripherals store.

As this project is part of my personal portfolio, I would be very happy to receive feedback on the project and perhaps some ways to improve it.

## The Project:

An API for peripherals store with IdentityUser Microsoft, authentication and jwt, has a complete crud for addresss, orders, products, users and promotions.

#### Products: You can add a new product, delete product, update product, search product by his id and get a list with all products.

#### Address: You can add a new Address, delete address, remove address, get a list of all adress, and search an address by his Id.

#### Order: You can add a new Order, delete Orders, update Orders, add a new product to an order and search order by her id 

#### User: You can register a new user and authenticate.

#### Promotion: It is possible to create a new promotion, remove promotion and add products to a promotion.

The API has loggers, is fully documented within the application, DTO's and automapper were also used.
The application was made using .net 7 with sql server.

## How to Run:
In order to run the project you will need to have Visual Studio installed.

With the project open, select the API_DDD_Loja_PerifericosFGH solution and do the following:
* Clean Solution
* Build Solution
* Restore NuGetPackages

Go to Package Manager console in Domain solution and execute the command:
* Update-Database

## Api Documentation

### User

#### Register a new User

```http
  POST /user/Register
```

| Parameter   | Type       | Description                           |
| :---------- | :--------- | :---------------------------------- |
| `email` | `string` | **Required**. User Email |
| `password` | `string` | **Required**. User Password |
| `cpf` | `string` | **Required**. User CPF |
| `cep` | `string` | **Optional**. User CEP |

#### Authenticate User

```http
  POST /user/Login
```

| Parameter   | Type       | Description                                   |
| :---------- | :--------- | :------------------------------------------ |
| `email`      | `string` | **Required**. Username |
| `password`      | `string` | **Required**. User Password |


Returns a jwt.

### Product

#### Get all Products list

```http
  GET /api/Products
```

Returns a list of products

#### Get a Product by id

```http
  GET /Products/get-by-id/{id}
```

| Parameter   | Type       | Description                                   |
| :---------- | :--------- | :------------------------------------------ |
| `Id`      | `id` | **Required**. Product id |


Returns a product.

#### Add a new Product

```http
  POST /api/Products
```

| Parameter   | Type       | Description                                   |
| :---------- | :--------- | :------------------------------------------ |
| `nome`      | `string` | **Required**. Product Name |
| `descricao`      | `string` | **Required**. Product Description |
| `preco`      | `decimal` | **Required**. Product Price |



#### Update Product

```http
  PUT /api/Products
```

| Parameter   | Type       | Description                                   |
| :---------- | :--------- | :------------------------------------------ |
| `Id`      | `id` | **Required**. Product Id |
| `nome`      | `string` | **Required**. Product Name |
| `descricao`      | `string` | **Required**. Product Description |
| `preco`      | `decimal` | **Required**. Product Price |

#### Delete Product

```http
  Delete /api/Products
```

| Parameter   | Type       | Description                                   |
| :---------- | :--------- | :------------------------------------------ |
| `Id`      | `id` | **Required**. Product Id |

### Promotion

#### Get all Promotions list

```http
  GET /api/Promotions
```

Returns a list of promotions

#### Get a Promotion by id

```http
  GET /api/Promotion/get-by-id/{id}
```

| Parameter   | Type       | Description                                   |
| :---------- | :--------- | :------------------------------------------ |
| `Id`      | `id` | **Required**. Promotion Id |


Returns a promotion.

#### Add a new Promotion

```http
  POST /api/Promotions
```

| Parameter   | Type       | Description                                   |
| :---------- | :--------- | :------------------------------------------ |
| `nome`      | `string` | **Required**. Promotion Name |

#### Update Promotion

```http
  PUT /api/Promotion
```

| Parameter   | Type       | Description                                   |
| :---------- | :--------- | :------------------------------------------ |
| `Id`      | `id` | **Required**. Promotion Id |
| `nome`      | `string` | **Required**. Promotion Name |

#### Delete Promotion

```http
  Delete /api/Promotion
```

| Parameter   | Type       | Description                                   |
| :---------- | :--------- | :------------------------------------------ |
| `Id`      | `id` | **Required**. Promotion Id |

#### Add a product to a promotion

```http
  POST /api/Promotions/add-product-promotion/
```

| Parameter   | Type       | Description                                   |
| :---------- | :--------- | :------------------------------------------ |
| `promotionId`      | `id` | **Required**. Promotion Id |
| `productsId`      | `string` | **Required**. Product Id |

#### Delete a product of a promotion

```http
  Delete /api/Promotion/delete-product-promotion/
```

| Parameter   | Type       | Description                                   |
| :---------- | :--------- | :------------------------------------------ |
| `promotionId`      | `id` | **Required**. Promotion Id |
| `productsId`      | `string` | **Required**. Product Id |

### Order

#### Get all orders list

```http
  GET /api/Order
```

Returns a list of orders

#### Get an order by id

```http
  GET /api/Order/get-by-id/{id}
```

| Parameter   | Type       | Description                                   |
| :---------- | :--------- | :------------------------------------------ |
| `Id`      | `id` | **Required**. Order Id |


Returns an order.

#### Create a new order

```http
  POST /api/Order
```

| Parameter   | Type       | Description                                   |
| :---------- | :--------- | :------------------------------------------ |
| `userId`      | `string` | **Required**. User Id |

#### Add a product to an order

```http
  POST /api/Order/add-order-product/
```

| Parameter   | Type       | Description                                   |
| :---------- | :--------- | :------------------------------------------ |
| `orderId`      | `id` | **Required**. Order Id |
| `productId`      | `string` | **Required**. Product Id |

#### Delete a product of an order

```http
  Delete /api/Order/delete-order-product/
```

| Parameter   | Type       | Description                                   |
| :---------- | :--------- | :------------------------------------------ |
| `orderId`      | `id` | **Required**. Order Id |
| `productId`      | `string` | **Required**. Product Id |

#### Delete Order

```http
  Delete /api/Order
```

| Parameter   | Type       | Description                                   |
| :---------- | :--------- | :------------------------------------------ |
| `Id`      | `id` | **Obrigatório**. Order id |


### Address

#### Get all Adress list

```http
  GET /api/Address
```

Returns a list of address

#### Get an Address by cep

```http
  GET /api/Address/get-by-cep/{cep}
```

| Parameter   | Type       | Description                                   |
| :---------- | :--------- | :------------------------------------------ |
| `cep`      | `int` | **Required**. Address Cep |


Returns an address.

#### Add a new Address

```http
  POST /api/Address
```

| Parameter   | Type       | Description                                   |
| :---------- | :--------- | :------------------------------------------ |
| `cep`      | `int` | **Required**. Address Cep |
| `rua`      | `string` | **Required**. Address Street |
| `bairro`      | `string` | **Required**. Address Neighborhood |
| `numero`      | `int` | **Required**. Address Number |
| `complemento`      | `string` | **Required**. Address Complement |



#### Update Address

```http
  PUT /api/Address
```

| Parameter   | Type       | Description                                   |
| :---------- | :--------- | :------------------------------------------ |
| `cep`      | `int` | **Required**. Address Cep |
| `rua`      | `string` | **Required**. Address Street |
| `bairro`      | `string` | **Required**. Address Neighborhood |
| `numero`      | `int` | **Required**. Address Number |
| `complemento`      | `string` | **Required**. Address Complement |

#### Delete Address

```http
  Delete /api/Address
```

| Parameter   | Type       | Description                                   |
| :---------- | :--------- | :------------------------------------------ |
| `cep`      | `int` | **Required**. Address Cep |

## Contact Me

-  [Linkedin](https://www.linkedin.com/in/jo%C3%A3o-paulo-marques-43ba10242/)
-  [Email](mailto:jpmarques2000@hotmail.com)

