#include <stdio.h>
#include <stdlib.h>
#include <iostream>
#include <GL\glew.h>
#include <GLFW\glfw3.h>

#include <glm\glm.hpp>
#include <glm\gtc\matrix_transform.hpp>
#include <glm\gtc\type_ptr.hpp> // do parsowania warto�ci

// glm::mat4 model(1.0f); lub glm::mat4 model = glm::mat4(1.0f);
// model = glm::mat(1.0f);



// wymiary okna
const GLint WIDTH = 800, HEIGHT = 600;
const float degreesInRadians = 3.14159265f / 180.0f;

GLuint VAO, VBO, shader, uniformModel;



bool direction = true;
float triOffset = 0.0f;
float triMaxOffset = 0.7f;
float triIncrement = 0.005f; // ruch o tyle od 0.0 do 0.7, bool zmieni kierunek ruchu

bool rotation = true;
float rotateBeg = 0.0f;
float rotateEnd = 3.14f;
float rotateIncrement = 0.1f;

bool scale = true;
float curScale = 0.1f;
float maxScale = 1.0f;
float minScale = 0.0f;

// pierwszy shader jeszcze nie wyodr�bniony do innego pliku
// Vertex Shader
//gl_Position wbudowana zmienna shadera
static const char* vShader = "													\n\
#version 330																	\n\
																				\n\
layout (location = 0) in vec3 pos;												\n\
																				\n\
uniform mat4 model;																\n\
																				\n\
																				\n\
void main()																		\n\
{																				\n\
	gl_Position	= model * vec4(pos, 1.0);										\n\
}";												// pos je�li nie zmieniamy �adnej warto�ci to mozna zamiast pos.x, pos.y, pos.z

// in = input, vec3 = 3-warto�ciowy wektor, 

//fShader - fragment shader
//out tutaj default = color
static const char* fShader = "											\n\
#version 330															\n\
																		\n\
out vec4 colour;														\n\
																		\n\
void main()																\n\
{																		\n\
	colour = vec4(1.0, 0.0, 0.0, 1.0);									\n\
}";


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

	glBufferData(GL_ARRAY_BUFFER, sizeof(vertices), vertices, GL_STATIC_DRAW); // staticdraw - niezmienialny rysunek, dynamicdraw - mo�na zmienia�

	glVertexAttribPointer(0, 3, GL_FLOAT, GL_FALSE, 0, 0);	//  INDEX = 0, SIZE = 3 (bo 3 wierzcho�ki), GL_FLOAT bo zmienne typu float, GL_FALSE bo nie jest normalizowane
	glEnableVertexAttribArray(0);

	glBindBuffer(GL_ARRAY_BUFFER, 0); // odbindowanie wczesniejszych bufor�w

	glBindVertexArray(0);	// odbindowanie arraya vertex�w
}

void AddShader(GLuint theProgram, const char* shaderCode, GLenum shaderType) {	// dodaje shadery do programu po kompilacji
	GLuint theShader = glCreateShader(shaderType);
	
	const GLchar* theCode[1]; // pierwszy element tablicy
	theCode[0] = shaderCode;

	GLint codeLenght[1];
	codeLenght[0] = strlen(shaderCode);

	glShaderSource(theShader, 1, theCode, codeLenght);
	glCompileShader(theShader);

	GLint result = 0;
	GLchar eLog[1024] = { 0 };	// najtrudniejsze do debugowania shadery, krok po kroku trzeba je debugowa�

	glGetShaderiv(theShader, GL_COMPILE_STATUS, &result);

	if (!result) {
		glGetShaderInfoLog(shader, sizeof(eLog), NULL, eLog);
		printf("Error compiling the %d shader: '%s'\n", shaderType, eLog);
		return;
	}

	glAttachShader(theProgram, theShader);
}

void CompileShaders() {	// ��czy wszystkie shadery z programem i waliduje go
	shader = glCreateProgram();

	if (!shader) {
		printf("Error creating shader program.");
		return;	// lepiej stworzy� wyj�tek
	}

	AddShader(shader, vShader, GL_VERTEX_SHADER);
	AddShader(shader, fShader, GL_FRAGMENT_SHADER);

	GLint result = 0;
	GLchar eLog[1024] = { 0 };	// najtrudniejsze do debugowania shadery, krok po kroku trzeba je debugowa�

	glLinkProgram(shader);
	glGetProgramiv(shader, GL_LINK_STATUS, &result);

	if (!result) {
		glGetProgramInfoLog(shader, sizeof(eLog), NULL, eLog);
		printf("Error linking program: '%s'\n", eLog);
		return;
	}

	glValidateProgram(shader);	// walidacja programu (czyli shader�w)
	glGetProgramiv(shader, GL_VALIDATE_STATUS, &result);

	if (!result) {
		glGetProgramInfoLog(shader, sizeof(eLog), NULL, eLog);
		printf("Error validating program: '%s'\n", eLog);
		return;
	}

	uniformModel = glGetUniformLocation(shader, "model");

}

int main()
{
	// inicjalizacja GLFW

	if (!glfwInit()) {
		printf("GLFW initialization failed!");
		glfwTerminate();
		return 1;	// error
	}

	// ustawienie w�a�ciwo�ci okna GLFW 
	// wersja OpenGL
	glfwWindowHint(GLFW_CONTEXT_VERSION_MAJOR, 3); // wersja nr 3 wi�c jest value = 3
	glfwWindowHint(GLFW_CONTEXT_VERSION_MINOR, 3);

	glfwWindowHint(GLFW_OPENGL_PROFILE, GLFW_OPENGL_CORE_PROFILE); // zabezpieczenie przed u�ywaniem przestarza�ego kodu, bez kompatybilno�ci wstecznej
	glfwWindowHint(GLFW_OPENGL_FORWARD_COMPAT, GL_TRUE);	// pozwala na kompatybilno�� przedni�


	GLFWwindow* mainWindow = glfwCreateWindow(WIDTH, HEIGHT, "MainWindow", NULL, NULL); // NULL1 sprawia �e nie ma fullscreena, a NULL2 sprawia, �e zasoby nie s� dzielone

	if (!mainWindow) {
		printf("GLFW window creation failed!");
		glfwTerminate();
		return 1;
	}

	// informacja nt rozmiaru Buffera
	int bufferWidth, bufferHeight;
	glfwGetFramebufferSize(mainWindow, &bufferWidth, &bufferHeight);

	// ustawienie kontekstu (context) dla GLEW
	glfwMakeContextCurrent(mainWindow); // mo�na okre�la�, kt�re okno jest g��wnym kontekstem (aktualnie)

	// pozwolenie na elementy nowoczesnych rozszerze� 
	glewExperimental = GL_TRUE;	// najlepiej wsz�dzie tak zrobi�
	
	// inicjalizacja glew
	if (glewInit() != GLEW_OK) {
		printf("GLEW initialization failed!");
		glfwDestroyWindow(mainWindow);
		glfwTerminate();
		return 1;
	}

	// ustawienie rozmiaru Viewport 
	glViewport(0, 0, bufferWidth, bufferHeight); // width inne ni� WIDTH i height inne ni� HEIGHT

	CreateTriangle();
	CompileShaders();


	// p�tla dop�ki okno nie jest zamkni�te
	while (!glfwWindowShouldClose(mainWindow))
	{
		// wydobycie i zarz�dzanie eventami inputu
		glfwPollEvents();

		if (direction) {
			triOffset += triIncrement;
		}
		else {
			triOffset -= triIncrement;
		}

		if (abs(triOffset) >= triMaxOffset) {
			direction = !direction;
		}

		if (rotation) {
			rotateBeg += rotateIncrement;
		}
		else {
			rotateBeg -= rotateIncrement;
		}
		
		if (abs(rotateBeg) >= rotateEnd) {
			rotation = !rotation;
		}

		if (scale) {
			curScale += 0.01f;
		}
		else {
			curScale -= 0.01f;
		}

		if (curScale >= maxScale) {
			scale = !scale;
		}
		if (curScale <= minScale) {
			scale = !scale;
		}

		glm::mat4 model(1.0f);	// matrix 4x4
		model = glm::translate(model, glm::vec3(triOffset, triOffset, 0.0f));
		model = glm::rotate(model, rotateBeg, glm::vec3(1.0f, 1.0f, 1.0f)); //fajnie si� kr�ci, zniekszta�cenia ze wzgl�du na to, w kt�rym "�wiecie" obraca si� tr�jk�t
		model = glm::scale(model, glm::vec3(curScale, 0.4f, 1.0f));	// je�li przed translate to skaluje si� te� translacja


		// wyczyszczenie okna
		glClearColor(1.0f, 0.5f, 0.0f, 1.0f);
		glClear(GL_COLOR_BUFFER_BIT);

		glUseProgram(shader);	// wybiera kt�ry program ma by� u�ywany

		glUniformMatrix4fv(uniformModel, 1, GL_FALSE, glm::value_ptr(model)); // false bo nie chcemy transponowa�, glm::value_ptr musi by� �eby wskaza� dok�adnie na warto�� modelu

		glBindVertexArray(VAO);

		glDrawArrays(GL_TRIANGLES, 0, 3);	// 3 bo jeden obiekt

		glBindVertexArray(0);
		glUseProgram(0);

		glfwSwapBuffers(mainWindow);
	}

	return 0;
}