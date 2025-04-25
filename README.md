# 📱 MauiAuthClient

## 📝 Sumário

- [Introdução](#introdução)
- [Funcionalidades](#funcionalidades)
- [Tecnologias Utilizadas](#tecnologias-utilizadas)
- [Como Rodar](#como-rodar)
- [Fluxo de Sessão com Token](#fluxo-de-sessão-com-token)
- [Upload de Imagens com Dropbox](#upload-de-imagens-com-dropbox)
- [Contribuição](#contribuição)
- [Licença](#licença)

---

## 📌 Introdução

**MauiAuthClient** é um aplicativo mobile desenvolvido com .NET MAUI que se conecta a uma API ASP.NET Core para realizar autenticação de usuários utilizando JWT. Este projeto é a base para um sistema completo de e-commerce, começando com toda a parte de autenticação, gerenciamento de conta e upload de imagens para o Dropbox.

---

## ✅ Funcionalidades

- 🧾 Criação de conta
- 🔐 Login e Logout
- ♻️ Sessão persistente com renovação automática de token (7 dias)
- 🔒 Troca de senha segura
- ☁️ Upload de imagens para Dropbox (com armazenamento do link, nome e descrição no banco)
- 👤 Edição de perfil do usuário

---

## 🧰 Tecnologias Utilizadas

- [.NET MAUI](https://learn.microsoft.com/en-us/dotnet/maui/)
- C#
- JWT para autenticação
- HTTPClient para consumo da API
- Dropbox API para upload de imagens

---

## ▶️ Como Rodar

1. Clone o repositório:
   ```bash
   git clone https://github.com/seu-usuario/MauiAuthClient.git
   cd MauiAuthClient
