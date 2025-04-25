# 📱 MauiAuthClient

[![Platform](https://img.shields.io/badge/platform-.NET%20MAUI-blueviolet?logo=dotnet)](https://learn.microsoft.com/en-us/dotnet/maui/)

---

## 📝 **Sumário**

- [Introdução](#Introdução)
- [Funcionalidades](#funcionalidades)
- [Fluxo de Login](#fluxo-de-login)
- [Tecnologias Utilizadas](#tecnologias-utilizadas)
- [Como Rodar](#como-rodar)
- [Repositório da API](#repositório-da-api)

---

## **Introdução**

**MauiAuthClient** é um aplicativo mobile desenvolvido com .NET MAUI que se conecta a uma API ASP.NET Core para realizar autenticação de usuários utilizando JWT. Este projeto é a base para um sistema completo de e-commerce, começando com toda a parte de autenticação e gerenciamento de conta.

---

## **Funcionalidades**

- 🧾 Criação de conta
- 🔐 Login e Logout
- 🔒 Troca de senha segura
- 👤 Edição de perfil do usuário
- ♻️ Sessão persistente com renovação automática de token (7 dias)

---

## **Fluxo de Login**

1. O usuário faz o login com email e senha;
2. Se as credenciais forem válidas, a API retorna um **token JWT**;
3. O token é armazenado localmente e a sessão é iniciada;
4. Sempre que o app é iniciado, ele verifica e **renova o token** automaticamente;
5. Ao fazer logout, o token é descartado e o usuário precisa logar novamente.

---

## **Tecnologias Utilizadas**

- [.NET MAUI](https://learn.microsoft.com/en-us/dotnet/maui/)
- C#
- JWT para autenticação
- HTTPClient para consumo da API

---

## **Como Rodar**

1. Clone o repositório:
   ```bash
   git clone https://github.com/seu-usuario/MauiAuthClient.git
   cd MauiAuthClient
2. Abra o projeto no Visual Studio 2022 ou superior com suporte a .NET MAUI.
3. Verifique se a URL base da API está corretamente configurada no app.
4. Compile e rode em um emulador Android, iOS ou dispositivo real.

-- 

## **Repositório da API**

A API que este app consome está disponível neste repositório:

👉 [API-CRUD-JWT_TOKEN](https://github.com/leonelmendes/API-CRUD-JWT_TOKEN)

--
