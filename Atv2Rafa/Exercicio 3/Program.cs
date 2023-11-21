using SkiaSharp;

namespace Projeto {
	class Program {
		static void Main(string[] args) {

			using (SKBitmap bitmapEntrada = SKBitmap.Decode("Exercicio 3.png")){
				
				unsafe {
					byte* entr = (byte*)bitmapEntrada.GetPixels();		

					int largura = bitmapEntrada.Width;
					int altura = bitmapEntrada.Height;
					
					int total = bitmapEntrada.Width * bitmapEntrada.Height;
					
					int [] pixels= new int[256];
                    int contados = 0;

					for (int y = 0; y < altura ; y++) {
						
						for (int x= 0; x < largura ; x++) {
							
							pixels[entr[y * largura + x ]] += 1;
						}
					}

                    for (int z=0; z<=255; z++){
						
                        Console.WriteLine("Pixels com valor "+ z +": "+ pixels[z]);
                        contados += pixels[z];
                    }   
                    Console.WriteLine("Totais: "   + total);
                    Console.WriteLine("Contados: " + contados);
                }
			}
		}
	}
}
