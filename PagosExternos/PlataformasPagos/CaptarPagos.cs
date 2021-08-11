using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Net;
using System.Net.Http;
using Newtonsoft.Json;
using System.Data;

namespace PlataformasPagos.CaptarPagos
{
    public class CaptarPagos
    {
        public static int IdEntidad { get; set; }
        public static string Hash { get; set; }

        public static Uri BaseAdress { get; set; }

        public enum TipoBusqueda
        {
            TODO = 0,
            PAGO = 1,
            IMPAGO = 2
        }

        public static Vencimiento[] GetVencimientos()
        {
            Vencimiento oVen1 = new Vencimiento("10", "0");
            Vencimiento oVen2 = new Vencimiento("20", "0");
            Vencimiento oVen3 = new Vencimiento("30", "0");
            Vencimiento[] oVen = new Vencimiento[3];
            oVen[0] = oVen1;
            oVen[1] = oVen2;
            oVen[2] = oVen3;

            return oVen;
        }

        public static async Task<List<BotonResponse>> GenerarBotonAsync(Boton oBoton)
        {
            string responseData="";
            using (var client = new HttpClient { BaseAddress = BaseAdress })
            {
                List<BotonResponse> lista = new List<BotonResponse>();

                // \"mediosDePago\": [        \"LINK_DEBITO\",        \"LINK_CREDITO\",        \"CODIGO_DE_BARRAS\",        \"TRANSFERENCIA\"
                string[] medios = { "LINK_DEBITO","LINK_CREDITO", "CODIGO_DE_BARRAS", "TRANSFERENCIA" };

                oBoton.MediosDePago = medios;
                Vencimiento oVen1 = new Vencimiento("10", "0");
                Vencimiento oVen2 = new Vencimiento("20", "0");
                Vencimiento oVen3 = new Vencimiento("30", "0");
                Vencimiento[] oVen = new Vencimiento[3];
                oVen[0] = oVen1;
                oVen[1] = oVen2;
                oVen[2] = oVen3;
                oBoton.Vencimientos = new Vencimiento();
                CreateBotonRequest oReq = new CreateBotonRequest();
                oReq.IdEntidad = IdEntidad;
                oReq.Buttons = new Boton[1];
                oReq.Buttons[0] = oBoton;

                string jsonString = JsonConvert.SerializeObject(oReq);

                client.DefaultRequestHeaders.TryAddWithoutValidation("hash",Hash);
                client.DefaultRequestHeaders.TryAddWithoutValidation("Accept", "*/*");
                using (var content = new StringContent(jsonString, System.Text.Encoding.UTF8, "application/json"))
                {
                    using (var response = await client.PostAsync("crearPago", content))
                    {
                        if (response.StatusCode == HttpStatusCode.OK)
                        {
                            responseData = await response.Content.ReadAsStringAsync();
                            if (!responseData.Contains("No Content"))
                            {
                                BotonResponse boton = JsonConvert.DeserializeObject<BotonResponse>(responseData);
                                lista.Add(boton);
                                return lista;
                            }
                            else
                                return new List<BotonResponse>();
                        }
                    }
                }
                return new List<BotonResponse>();
            }
        }

        public static async Task<DataReport[]> ListarBotones(DateTime desde, DateTime hasta,TipoBusqueda busqueda)
        {
            DataReport[] botonesGenerados;
            DataReport[] arrayVacio = new DataReport[1];

            string responseData = "";
            try
            {
                using (var httpClient = new HttpClient { BaseAddress = BaseAdress })
                {
                    ReporteRequest oRequest = new ReporteRequest();
                    oRequest.IdEntidad = IdEntidad;
                    oRequest.Desde = desde;
                    oRequest.Hasta = hasta;
                    oRequest.Tipo = (int)busqueda;
                    string jsonString = JsonConvert.SerializeObject(oRequest);
                    httpClient.DefaultRequestHeaders.TryAddWithoutValidation("hash", Hash);
                   //var content = new StringContent("{ \"idEntidad\": " + IdEntidad.ToString() + ",\"desde\": \"2020-03-01 00:00:00\",\"hasta\": \"2020-04-01 00:00:00\",\"tipo\": 1}", System.Text.Encoding.UTF8, "application/json"
                    using (var content = new StringContent(jsonString, System.Text.Encoding.UTF8, "application/json"))
                    {
                        using (var response = await httpClient.PostAsync("getReportes", content))
                        {
                            if(response.StatusCode == HttpStatusCode.OK)
                            {
                                responseData = await response.Content.ReadAsStringAsync();
                                if (!responseData.Contains("No Content"))
                                {
                                    ReporteReposnse boton = JsonConvert.DeserializeObject<ReporteReposnse>(responseData);
                                    botonesGenerados = boton.Data;
                                    return botonesGenerados;
                                }
                                else
                                {
                                    arrayVacio[0] = new DataReport(-1,"No se encontraron resultados" );
                                    return arrayVacio;
                                }
                            }
                            else
                            {
                                arrayVacio[0] = new DataReport(-2, response.StatusCode.ToString());
                                return arrayVacio;
                            }
                        }
                    }
                }
            }
            catch (Exception x)
            {
                responseData = x.ToString();
                arrayVacio[0] = new DataReport(-2,responseData);
            }
            return arrayVacio;
        }

        public static async Task<List<ReporteReposnse>> ListarBotones()
        {
            List<ReporteReposnse> lista = new List<ReporteReposnse>();
            string responseData = "";
            try
            {
                using (var httpClient = new HttpClient { BaseAddress = BaseAdress })
                {
                    ReporteRequestById oRequest = new ReporteRequestById();
                    oRequest.IdEntidad = 1197;
                    oRequest.IdCliente = 0;
                    oRequest.IdContrato = 0;

                    HttpRequestMessage oReq = new HttpRequestMessage();
                    oReq.Method = HttpMethod.Get;
                    string jsonString = JsonConvert.SerializeObject(oRequest);
                    oReq.Content = new StringContent(jsonString, System.Text.Encoding.UTF8, "application/json");
                    oReq.RequestUri = new Uri("https://backend-test.captarpagos.com/api/ws/getReportes");
                    httpClient.DefaultRequestHeaders.TryAddWithoutValidation("hash", "a22a6e5-b5a0-be4a-b332-e4cbff8c1a4d0");
                    //var content = new StringContent("{ \"idEntidad\": " + IdEntidad.ToString() + ",\"desde\": \"2020-03-01 00:00:00\",\"hasta\": \"2020-04-01 00:00:00\",\"tipo\": 1}", System.Text.Encoding.UTF8, "application/json"
                    using (var content = new StringContent(jsonString, System.Text.Encoding.UTF8, "application/json"))
                    {
                        string aux = content.ToString();
                        using (var response = await httpClient.SendAsync(oReq))
                        {
                            if (response.StatusCode == HttpStatusCode.OK)
                            {
                                responseData = await response.Content.ReadAsStringAsync();
                                if (!responseData.Contains("No Content"))
                                {
                                    List<ReporteReposnse> list = JsonConvert.DeserializeObject<List<ReporteReposnse>>(responseData);
                                    //ReporteReposnse responseReporte = JsonConvert.DeserializeObject<ReporteReposnse>(responseData);
                                    return list;
                                }
                                else
                                    return lista;

                            }

                        }
                    }
                }

            }
            catch (Exception x)
            {
                responseData = x.ToString();
            }
            return lista;
        }

    }
}