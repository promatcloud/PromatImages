<h1 align="center">
<img src="https://github.com/promatcloud/Branding/blob/master/icons/org/promat.512.png" alt="promat" width="256"/>
 <br/>
 PromatImages
</h1>

<div align="center">

[![Build status](https://ci.appveyor.com/api/projects/status/0by9pq4npd3k6fto?svg=true)](https://ci.appveyor.com/project/promatcloud/promatimages)
[![NuGet Badge](https://buildstats.info/nuget/Promat.Images?includePreReleases=true)](https://www.nuget.org/packages/Promat.Images/)

</div>

Librería para combinar, redimensionar y reescalar imágenes que por debajo utiliza [ImageSharp](https://github.com/SixLabors/ImageSharp).

**Importante!!! => el paquete NuGet estará en versión beta mientras ImageSharp lo esté**
PromatImages is available from: **NuGet [PromatImages](https://www.nuget.org/packages/Promat.Images)**

# Composición

Podemos crear fácilmente una composición a partir de varias imágenes para ello debemos:
 - Comenzar por indicar las características del lienzo
 - Añadir tantas imágenes como queramos a la composición (configurando su tamaño, opacidad y localización)
 - Generar la composición
 ```csharp
    // Iniciamos la composición indicando que será de 512 x 512 pixels
    var resultImage = Composition.Begin(512, 512)
        // Añadimos las imágenes
        // la primera imagen se dibujará en un tamaño de 400 x 400 en el centro de la composición
        .Add(Images[0], 400, 400, ContentAlignment.MiddleCenter)
        // la sengunda imagen se dibujará en un tamaño de 350 x 350 en el centro de la composición
        .Add(Images[1], 350, 350, ContentAlignment.MiddleCenter)
        // la tercera imagen se dibujará en un tamaño de 256 x 256 en la esquiña inferior izquiera de la composición 
        // y ademas la desplazaremos 40 px más a la iaquiera y 5 px más hacia abajo
        .Add(Images[2], 256, 256, ContentAlignment.BottomLeft, -40, 5)
        // Obtenemos la composición con los parámetros configurados anteriormente
        .Compose();
    // Guardamos la composición
    resultImage.Save(Path.Combine(OutputPath, "composition2.png"));
 ```

# Transformación
## Redimensionamiento

Para cambiar el tamaño con la función "Resize" solo necesitamos indicanr imagen y el tamaño deseado.

 ```csharp
    // Redimensionar a partir de un System.Drawing.Image o System.Drawing.Bitmap
    Image miImagenRedimensionada1 = Transformation.Resize(Resources.PromatLogo, 32, 32);
 ```
o
 ```csharp
    // Redimensionar a partir de un archivo
    string imagenFile = @"C:\Users\Usuario\Pictures\mi_imagen.png";
    Image miImagenRedimensionada2 = Transformation.Resize(imagenFile, 16, 16);
 ```
 
## Reescalado

El reescalado redimensionará la imagen al ancho o alto máximo indicado, según su relación de aspecto y manteniendo dicha relación.
Solo necesitamos indicanr imagen y el tamaño deseado.

 ```csharp
    // Reescalado a partir de un System.Drawing.Image o System.Drawing.Bitmap
    Image miImagenReescalada1 = Transformation.Scale(Resources.PromatLogo, 150, 120);
 ```
o
 ```csharp
    // Reescalado a partir de un archivo
    string imagenFile = @"C:\Users\Usuario\Pictures\mi_imagen.png";
    Image miImagenReescalada2 = Transformation.Scale(imagenFile, 75, 50);
 ```

## Opacidad

Mediante la función "Opacity" podemos cambiar la opacidad de una imagen; sólo necesitamos indicar la imagen y el nivel de opacidad deseado.

 ```csharp
    // Cambiar la opacidad a partir de un System.Drawing.Image o System.Drawing.Bitmap
    Image miImagenSemitransparente1 = Transformation.Opacity(Resources.PromatLogo, 0.5f);
 ```
o
 ```csharp
    // Cambiar la opacidad a partir de un archivo
    string imagenFile = @"C:\Users\Usuario\Pictures\mi_imagen.png";
    Image miImagenSemitransparente2 = Transformation.Opacity(imagenFile, 0.5f);
 ```

