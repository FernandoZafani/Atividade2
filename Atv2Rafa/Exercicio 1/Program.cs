using SkiaSharp;

namespace Projeto{

	class Program{

        static unsafe int procurarPadrao(byte* entr, byte[] forma, int altura, int largura){
            int contador=0;
            	for (int y = 0; y < altura - 3; y++){
					
					for (int x = 0; x < largura - 3; x++){
						bool achar = true;
						
						    for (int py = 0; py < 4; py++){
								
								for (int px = 0; px < 4; px++){
									
									byte* atual = entr + ((y + py) * largura + (x + px));
									byte vlr_pix = atual[0];
									
									if (vlr_pix != forma[py * 4 + px]){
										achar = false;
										break;
									}
								}
								if (!achar){
									break;
								}
							}
							if (achar){
								contador++;
							}
						}
					}

            return contador;
        }

		static void Main(string[] args){

			using (SKBitmap bitmap = SKBitmap.Decode("Exercicio 1.png")){
				
    			int largura = bitmap.Width;
				int altura = bitmap.Height;
				
                int cont_f = 0;
				unsafe{
					byte* entr = (byte*)bitmap.GetPixels();
					byte[] forma = new byte[]{
						0, 0, 0, 0,
						0, 255, 255, 0,
						0, 255, 255, 0,
						0, 0, 0, 0
					};

                    cont_f = procurarPadrao(entr, forma, largura, altura);
				}
				Console.WriteLine(cont_f + " Aparições!");
			}
		}
	}
}
