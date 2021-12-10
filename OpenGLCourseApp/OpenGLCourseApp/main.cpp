#include <stdio.h>
#include <GL/glew.h>
#include <GLFW/glfw3.h>

// wymiary okna
const GLint WIDTH = 800, HEIGHT = 600;

GLuint VAO, VBO, shader;

// pierwszy shader jeszcze nie wyodrêbniony do innego pliku
// Vertex Shader
static const char* vShader = "					\n\
#version 330									\n\
												\n\
layout (location = 0) in vec3 pos;				\n\
";

// in = input, vec3 = 3-wartoœciowy wektor, 


void CreateTriangle() {
	GLfloat vertices[] = {
		-1.0f, -1.0f, 0.0f,
		1.0f, -1.0f, 0.0f,
		0.0f, 1.0f, 0.0f
	};

	glGenVertexArrays(1, &VAO);
	glBindVertexArray(VAO); // bindowanie VAOid do VAO

	glGenBuffers(1, &VBO);
	glBindBuffer(GL_ARRAY_BUFFER, VBO);

	glBufferData(GL_ARRAY_BUFFER, sizeof(vertices), vertices, GL_STATIC_DRAW); // staticdraw - niezmienialny rysunek, dynamicdraw - mo¿na zmieniaæ

	glVertexAttribPointer(0, 3, GL_FLOAT, GL_FALSE, 0, 0);	//  INDEX = 0, SIZE = 3 (bo 3 wierzcho³ki), GL_FLOAT bo zmienne typu float, GL_FALSE bo nie jest normalizowane
	glEnableVertexAttribArray(0);

	glBindBuffer(GL_ARRAY_BUFFER, 0); // odbindowanie wczesniejszych buforów

	glBindVertexArray(0);	// odbindowanie arraya vertexów
}

int main()
{
	// inicjalizacja GLFW

	if (!glfwInit()) {
		printf("GLFW initialization failed!");
		glfwTerminate();
		return 1;	// error
	}

	// ustawienie w³aœciwoœci okna GLFW 
	// wersja OpenGL
	glfwWindowHint(GLFW_CONTEXT_VERSION_MAJOR, 3); // wersja nr 3 wiêc jest value = 3
	glfwWindowHint(GLFW_CONTEXT_VERSION_MINOR, 3);

	glfwWindowHint(GLFW_OPENGL_PROFILE, GLFW_OPENGL_CORE_PROFILE); // zabezpieczenie przed u¿ywaniem przestarza³ego kodu, bez kompatybilnoœci wstecznej
	glfwWindowHint(GLFW_OPENGL_FORWARD_COMPAT, GL_TRUE);	// pozwala na kompatybilnoœæ przedni¹


	GLFWwindow* mainWindow = glfwCreateWindow(WIDTH, HEIGHT, "MainWindow", NULL, NULL); // NULL1 sprawia ¿e nie ma fullscreena, a NULL2 sprawia, ¿e zasoby nie s¹ dzielone

	if (!mainWindow) {
		printf("GLFW window creation failed!");
		glfwTerminate();
		return 1;
	}

	// informacja nt rozmiaru Buffera
	int bufferWidth, bufferHeight;
	glfwGetFramebufferSize(mainWindow, &bufferWidth, &bufferHeight);

	// ustawienie kontekstu (context) dla GLEW
	glfwMakeContextCurrent(mainWindow); // mo¿na okreœlaæ, które okno jest g³ównym kontekstem (aktualnie)

	// pozwolenie na elementy nowoczesnych rozszerzeñ 
	glewExperimental = GL_TRUE;	// najlepiej wszêdzie tak zrobiæ
	
	// inicjalizacja glew
	if (glewInit() != GLEW_OK) {
		printf("GLEW initialization failed!");
		glfwDestroyWindow(mainWindow);
		glfwTerminate();
		return 1;
	}

	// ustawienie rozmiaru Viewport 
	glViewport(0, 0, bufferWidth, bufferHeight); // width inne ni¿ WIDTH i height inne ni¿ HEIGHT

	// pêtla dopóki okno nie jest zamkniête
	while (!glfwWindowShouldClose(mainWindow))
	{
		// wydobycie i zarz¹dzanie eventami inputu
		glfwPollEvents();

		// wyczyszczenie okna
		glClearColor(1.0f, 0.5f, 0.0f, 1.0f);
		glClear(GL_COLOR_BUFFER_BIT);

		glfwSwapBuffers(mainWindow);
	}

	return 0;
}