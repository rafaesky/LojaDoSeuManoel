# LojaDoSeuManoel

## Descrição

Esta API Web automatiza o processo de embalagem de pedidos em uma loja de jogos online. Ela recebe pedidos em formato JSON com produtos e suas dimensões, determinando as caixas mais adequadas e quais produtos irão em cada uma.

## Funcionalidades

- Recebe pedidos com produtos e dimensões.
- Calcula a melhor forma de embalar os produtos.
- Retorna as caixas utilizadas e quais produtos estão em cada caixa.

## Tecnologias

- .NET Core 8
- C#
- Docker

## Exemplo de Uso

### Solicitação

Para enviar um pedido à API, use o seguinte formato JSON:

```json
{
  "pedidos": [
    {
      "pedido_id": 1,
      "produtos": [
        {
          "produto_id": "Webcam",
          "dimensoes": {
            "altura": 10,   // Altura em centímetros
            "largura": 25,  // Largura em centímetros
            "comprimento": 15 // Comprimento em centímetros
          }
        },
        {
          "produto_id": "Monitor",
          "dimensoes": {
            "altura": 50,   // Altura em centímetros
            "largura": 30,  // Largura em centímetros
            "comprimento": 60 // Comprimento em centímetros
          }
        }
      ]
    }
  ]
}
