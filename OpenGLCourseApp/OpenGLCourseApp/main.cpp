#include <stdio.h>
#include <GL/glew.h>
#include <GLFW/glfw3.h>

// wymiary okna
const GLint WIDTH = 800, HEIGHT = 600;

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

	// p�tla dop�ki okno nie jest zamkni�te
	while (!glfwWindowShouldClose(mainWindow))
	{
		// wydobycie i zarz�dzanie eventami inputu
		glfwPollEvents();

		// wyczyszczenie okna
		glClearColor(1.0f, 0.5f, 0.0f, 1.0f);
		glClear(GL_COLOR_BUFFER_BIT);

		glfwSwapBuffers(mainWindow);
	}

	return 0;
}