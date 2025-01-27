# O Jogo da Vida de Conway

O **Conway's Game of Life** é um autômato celular criado pelo matemático britânico **John Horton Conway** em 1970. É um jogo de simulação que não requer interação direta do jogador após o início, sendo considerado um exemplo clássico de como regras simples podem gerar comportamentos complexos.

## Regras do Jogo

O jogo ocorre em uma grade bidimensional, onde cada célula pode estar em um de dois estados: **viva** ou **morta**. A evolução do jogo se dá em "gerações", seguindo as seguintes regras:

1. **Sobrevivência**: 
   - Uma célula viva permanece viva se tiver 2 ou 3 vizinhos vivos.
   
2. **Morte por isolamento ou superpopulação**:
   - Uma célula viva morre se tiver menos de 2 vizinhos vivos (isolamento) ou mais de 3 vizinhos vivos (superpopulação).
   
3. **Nascimento**:
   - Uma célula morta torna-se viva se tiver exatamente 3 vizinhos vivos.

## Características

- **Inicialização**: O jogo começa com uma configuração inicial de células vivas escolhida pelo usuário ou gerada aleatoriamente.
- **Sem fim definido**: O jogo pode continuar indefinidamente, dependendo da configuração inicial.
- **Emergência de padrões**: Configurações iniciais podem gerar padrões complexos, como:
  - **Osciladores**: Padrões que se repetem em ciclos.
  - **Naves**: Padrões que se movem pela grade.
  - **Objetos estáticos**: Padrões que não mudam ao longo do tempo.

## Este Projeto

Este projeto foi criado a partir do artigo na Wikipédia sobre o **Jogo da Vida**: [Jogo da Vida - Wikipédia](https://pt.wikipedia.org/wiki/Jogo_da_vida). A implementação utiliza **SDL** para exibir a simulação na tela, com as bindings do **ppy.SDL2-CS**.

### Tecnologias Utilizadas
- **SDL**: Biblioteca para renderização e manipulação gráfica.
- **ppy.SDL2-CS**: Bindings em C# para facilitar o uso da SDL.
