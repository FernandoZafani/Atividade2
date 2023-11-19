using SkiaSharp;

namespace Projeto {
	class Program {
		static void Main(string[] args) {
			using (SKBitmap bitmapEntrada = SKBitmap.Decode("C:\\Users\\fernando.filho\\Desktop\\Atv2Rafa\Exercicio 2\entrada\\lenna.png"),
				bitmapSaida = new SKBitmap(new SKImageInfo(bitmapEntrada.Width, bitmapEntrada.Height, SKColorType.Gray8))) {
					
				static void Brilho(byte r, byte g, byte b, out byte saida) {
					unsafe{
						
						double R = (double)r / 255.0;
						double G = (double)g / 255.0;
						double B = (double)b / 255.0;

						double max = Math.Max(Math.Max(R, G), B);
						double V = max;

						double v =255.0 * V;
						saida = 0;
						
						if (v < 0){
							saida = (byte)(saida * (1 + v));
						}else{
							saida = (byte)(saida + ((255 - saida) * v));
						}	

						if(saida < 0){
							saida = 0;
						}
						if(saida > 255){
							saida = 255;
						}	
					}							
				}

					unsafe {
						byte* entr = (byte*)bitmapEntrada.GetPixels();
						byte* saida = (byte*)bitmapSaida.GetPixels();

						int largura = bitmapEntrada.Width;
						int altura = bitmapEntrada.Height;
						long total = bitmapEntrada.Width * bitmapEntrada.Height;

						unsafe{
							for (int e = 0, s = 0; s < total; e += 4, s++) {
								
								Brilho(entr[e + 2] , entr[e + 1] , entr[e], out saida[s]) ;
							}
						}							
					}
					unsafe{
						using (FileStream stream = new FileStream("C:\\Users\\fernando.filho\\desktop\\Atv2Rafa\\Exercicio 2\\entradaExercicio2Saida.png", FileMode.OpenOrCreate, FileAccess.Write)) {
							bitmapSaida.Encode(stream, SKEncodedImageFormat.Png, 100);
						}
					}
			}	
		}
	}
}
