using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// serve para determinar qual estado do jogo está acontecendo
/*
START: início, só seta a HUD do jogador e do inimigo
TURNOJOGADOR: turno do jogador, pode atacar (apertando o botão de atacar) ou curar (apertando o botão de curar)
TURNOINIMIGO: turno do inimigo, ataca o jogador
GANHOU: caso o jogador ganhou
PERDEU: caso o jogador perdeu
*/
public enum EstadoDeBatalha { START, TURNOJOGADOR, TURNOINIMIGO, GANHOU, PERDEU }

public class SistemaDeBatalha : MonoBehaviour
{
    public GameObject prefabJogador; // variável que armazena o jogador
	public GameObject prefabInimigo; // variável que armazena o inimigo

	public Transform estacaoBatalhaJogador; // variável que armazena o local onde o jogador fica
	public Transform estacaoBatalhaInimigo; // variável que armazena o local onde o inimigo fica

	Unidade unidadeJogador; // script do jogador
	Unidade unidadeInimigo; // script do inimigo

	public Text textoDeDialogo; // variável que armazena o texto que fica na caixa com os botões "atacar" e "curar"

	public HUDDeBatalha HUDJogador; // variável que armazena o HUD do jogador
	public HUDDeBatalha HUDInimigo; // variável que armazena o HUD do inimigo

	public GameObject prefabFila;
	FilaDeJogadores fila;

	public int contador = 0;

	public EstadoDeBatalha estado; // variável que armazena o estado da batalha

    // Start é chamado antes de tudo
    void Start() {
		estado = EstadoDeBatalha.START; // seta o estado de batalha para START
		StartCoroutine(SetarBatalha()); // chama a função que seta a batalha no início
    }

	// função que seta a batalha no início
	IEnumerator SetarBatalha() {
		GameObject GOJogador = Instantiate(prefabJogador, estacaoBatalhaJogador); // coloca o jogador no local que deve ficar
		unidadeJogador = GOJogador.GetComponent<Unidade>(); // armazena somente o script do jogador

		GameObject GOInimigo = Instantiate(prefabInimigo, estacaoBatalhaInimigo); // coloca o inimigo no local que deve ficar
		unidadeInimigo = GOInimigo.GetComponent<Unidade>(); // armazena somente o script do inimigo

		GameObject GOFila = Instantiate(prefabFila);
		fila = GOFila.GetComponent<FilaDeJogadores>();

		fila.insere(unidadeJogador);
		fila.insere(unidadeInimigo);

		textoDeDialogo.text = "Um bravo " + unidadeInimigo.nomeDaUnidade + " se aproxima..."; // escreve isso na caixa com os botões

		HUDJogador.SetHUD(unidadeJogador); // seta a HUD inicial do jogador
		HUDInimigo.SetHUD(unidadeInimigo); // seta a HUD inicial do inimigo

		yield return new WaitForSeconds(2f); // espera um tempo

		Unidade jogador = fila.getPlayer(); // a

		TurnoDeQuem();

		/*if (jogador.nomeDaUnidade == "Guerreiro1") {
			estado = EstadoDeBatalha.TURNOJOGADOR; // se torna a vez do jogador
			TurnoJogador(); // chama o método do turno do jogador
		} else {
			estado = EstadoDeBatalha.TURNOINIMIGO; // se torna a vez do inimigo
			TurnoInimigo(); // chama o método do turno do inimigo
		}*/
	}

	public bool Atacar() {
		textoDeDialogo.text = fila.getPlayer().nomeDaUnidade + " ataca!";

		new WaitForSeconds(1f);

		return fila.getHeader().next.player.TomarDano(fila.getPlayer().dano);
	}

	public void TurnoDeQuem() {
		fila.remove();
		if (fila.getPlayer().nomeDaUnidade == "Guerreiro1") {
			estado = EstadoDeBatalha.TURNOJOGADOR; // se torna a vez do jogador
			TurnoJogador(); // chama o método do turno do jogador
		} else {
			estado = EstadoDeBatalha.TURNOINIMIGO; // se torna a vez do inimigo
			StartCoroutine(TurnoInimigo()); // chama o método do turno do inimigo
		}
	}

	// método que é chamado quando o jogador ataca
	IEnumerator JogadorAtaca() {
		bool estaMorto = Atacar();

		HUDInimigo.SetVida(unidadeInimigo); // seta a vida do inimigo no HUD
		textoDeDialogo.text = "O ataque foi efetuado!";

		yield return new WaitForSeconds(2f); // espera um tempo

		if(estaMorto) { // se matou o personagem
			estado = EstadoDeBatalha.GANHOU; // o jogador venceu
			TerminarBatalha();
		} else { // se não matou o personagem
			TurnoDeQuem();
		/*
			estado = EstadoDeBatalha.TURNOINIMIGO; // é a vez do inimigo
			StartCoroutine(TurnoInimigo()); // começa a rotina de turno do inimigo*/
		}
	}

	// metodo que é chamado quando é a vez do inimigo
	IEnumerator TurnoInimigo() {
		contador = 0;
		bool estaMorto = Atacar();

		HUDJogador.SetVida(unidadeJogador); // seta a vida do jogador no HUD

		yield return new WaitForSeconds(1f); // espera um tempo

		if(estaMorto) { // se matou o personagem
			estado = EstadoDeBatalha.PERDEU; // o jogador perdeu
			TerminarBatalha();
		} else { // se não matou o personagem
			TurnoDeQuem();
		/*
			estado = EstadoDeBatalha.TURNOJOGADOR; // é a vez do jogador
			TurnoJogador();*/
		}

	}

	// procedimento que é chamado quando a batalha será encerrada
	void TerminarBatalha() {
		if(estado == EstadoDeBatalha.GANHOU) { // se o jogador ganhou
			textoDeDialogo.text = "Você ganhou a batalha!";
		} else if (estado == EstadoDeBatalha.PERDEU) { // se o jogador perdeu
			textoDeDialogo.text = "Você foi derrotado.";
		}
	}

	// procedimento que é chamado quando é o turno do jogador
	void TurnoJogador() {
		textoDeDialogo.text = "Escolha uma ação:";
	}

	// método chamado quando o botão de cura é acionado
	IEnumerator CurarJogador() {
		unidadeJogador.Curar(7f); // chama o procedimento da Unidade que a cura (aumenta sua vida)

		HUDJogador.SetVida(unidadeJogador); // seta a vida do jogador no HUD
		textoDeDialogo.text = "Você foi curado!";

		yield return new WaitForSeconds(2f); // espera um tempo

		TurnoDeQuem();
		/*
		estado = EstadoDeBatalha.TURNOINIMIGO; // se torna o turno do inimigo
		StartCoroutine(TurnoInimigo()); // começa a rotina de turno do inimigo*/
	}

	// procedimento chamado quando o botão de atacar é clicado
	public void ClicouBotaoAtacar() {
		if (estado != EstadoDeBatalha.TURNOJOGADOR) // se não estiver no turno do jogador, não faz nada
			return;
		contador++;
		if (contador == 1)
			StartCoroutine(JogadorAtaca()); // começa a rotina de ataque do jogador
	}

	// procedimento chamado quando o botão de curar é clicado
	public void ClicouBotaoCurar() {
		if (estado != EstadoDeBatalha.TURNOJOGADOR) // se não estiver no turno do jogador, não faz nada
			return;
		contador++;
		if (contador == 1)
			StartCoroutine(CurarJogador()); // começa a rotina de curar do jogador
	}

}
