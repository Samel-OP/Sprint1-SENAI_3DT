import axios from "axios";

export const LerConteudoImagem = async (FormData) => {

    let resultado;

    await axios({
        method : "POST",
        url : "https://equipamentos-ocr.cognitiveservices.azure.com/vision/v3.2/ocr?language=unk&detectOrientation=true&model-version=latest",
        data : FormData,
        headers  : {
            "Content-Type" : "multipart/form-data",
            "Ocp-Apim-Subscription-Key" : "e20b51403e134fd185063738e78ca7d3"
        }
    })
    .then(response => {
        // console.log(resultado)
        resultado = FiltrarOBJ(response.data)
    })
    .catch(erro => console.log(erro))
    
    return resultado;
}

export const FiltrarOBJ = (obj) => {

    let resultado;

    obj.regions.forEach(region => {
        region.lines.forEach(line => {
            line.words.forEach(word => {
                if(word.text[0] === "1" && word.text[1] === "2") {
                   resultado = word.text; 
                }
            });
        });
    });

    return resultado;
}