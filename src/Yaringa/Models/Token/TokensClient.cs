using System.Collections.Generic;
using System.Net.Http;

namespace Yaringa.Models.Token
{
    #pragma warning disable // Disable all warnings

    [System.CodeDom.Compiler.GeneratedCode("NSwag", "11.19.0.0 (NJsonSchema v9.10.72.0 (Newtonsoft.Json v9.0.0.0))")]
    public partial interface ITokensClient {
        /// <exception cref="SwaggerException">A server side error occurred.</exception>
        System.Threading.Tasks.Task<TokenDTO> CreateAsync(TokenCreationDTO dto);

        /// <exception cref="SwaggerException">A server side error occurred.</exception>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        System.Threading.Tasks.Task<TokenDTO> CreateAsync(TokenCreationDTO dto, System.Threading.CancellationToken cancellationToken);

        /// <exception cref="SwaggerException">A server side error occurred.</exception>
        System.Threading.Tasks.Task<TokenDTO> RefreshAsync(TokenRefreshDTO dto);

        /// <exception cref="SwaggerException">A server side error occurred.</exception>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        System.Threading.Tasks.Task<TokenDTO> RefreshAsync(TokenRefreshDTO dto, System.Threading.CancellationToken cancellationToken);
    }

    [System.CodeDom.Compiler.GeneratedCode("NSwag", "11.19.0.0 (NJsonSchema v9.10.72.0 (Newtonsoft.Json v9.0.0.0))")]
    public partial class TokensClient : ITokensClient
    {
        private string _baseUrl = "";
        private System.Lazy<Newtonsoft.Json.JsonSerializerSettings> _settings;
    
        public TokensClient(string baseUrl)
        {
            BaseUrl = baseUrl; 
            _settings = new System.Lazy<Newtonsoft.Json.JsonSerializerSettings>(() => 
            {
                var settings = new Newtonsoft.Json.JsonSerializerSettings();
                UpdateJsonSerializerSettings(settings);
                return settings;
            });
        }
    
        public string BaseUrl 
        {
            get { return _baseUrl; }
            set { _baseUrl = value; }
        }
    
        protected Newtonsoft.Json.JsonSerializerSettings JsonSerializerSettings { get { return _settings.Value; } }
    
        partial void UpdateJsonSerializerSettings(Newtonsoft.Json.JsonSerializerSettings settings);
        partial void PrepareRequest(System.Net.Http.HttpClient client, System.Net.Http.HttpRequestMessage request, string url);
        partial void PrepareRequest(System.Net.Http.HttpClient client, System.Net.Http.HttpRequestMessage request, System.Text.StringBuilder urlBuilder);
        partial void ProcessResponse(System.Net.Http.HttpClient client, System.Net.Http.HttpResponseMessage response);
    
        /// <exception cref="SwaggerException">A server side error occurred.</exception>
        public System.Threading.Tasks.Task<TokenDTO> CreateAsync(TokenCreationDTO dto)
        {
            return CreateAsync(dto, System.Threading.CancellationToken.None);
        }
    
        /// <exception cref="SwaggerException">A server side error occurred.</exception>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        public async System.Threading.Tasks.Task<TokenDTO> CreateAsync(TokenCreationDTO dto, System.Threading.CancellationToken cancellationToken)
        {
            var urlBuilder_ = new System.Text.StringBuilder();
            urlBuilder_.Append(BaseUrl != null ? BaseUrl.TrimEnd('/') : "").Append("/api/token");
    
            var client_ = new System.Net.Http.HttpClient();
            try
            {
                using (var request_ = new System.Net.Http.HttpRequestMessage())
                {
                    var formDataDictionary = new Dictionary<string, string>()
                    {
                         {"client_id", dto.Client_id },
                         {"username", dto.Username },
                         {"password", dto.Password },
                         {"grant_type", "password" }
                    };

                    var formData = new FormUrlEncodedContent(formDataDictionary);


                    //var content_ = new System.Net.Http.StringContent(Newtonsoft.Json.JsonConvert.SerializeObject(dto, _settings.Value));
                    var content_ = formData;

                    content_.Headers.ContentType = System.Net.Http.Headers.MediaTypeHeaderValue.Parse("application/x-www-form-urlencoded");
                    request_.Content = content_;
                    request_.Method = new System.Net.Http.HttpMethod("POST");
                    request_.Headers.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
    
                    PrepareRequest(client_, request_, urlBuilder_);
                    var url_ = urlBuilder_.ToString();
                    request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);
                    PrepareRequest(client_, request_, url_);
    
                    var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                    try
                    {
                        var headers_ = System.Linq.Enumerable.ToDictionary(response_.Headers, h_ => h_.Key, h_ => h_.Value);
                        if (response_.Content != null && response_.Content.Headers != null)
                        {
                            foreach (var item_ in response_.Content.Headers)
                                headers_[item_.Key] = item_.Value;
                        }
    
                        ProcessResponse(client_, response_);
    
                        var status_ = ((int)response_.StatusCode).ToString();
                        if (status_ == "200") 
                        {
                            var responseData_ = response_.Content == null ? null : await response_.Content.ReadAsStringAsync().ConfigureAwait(false); 
                            var result_ = default(TokenDTO); 
                            try
                            {
                                result_ = Newtonsoft.Json.JsonConvert.DeserializeObject<TokenDTO>(responseData_, _settings.Value);
                                return result_; 
                            } 
                            catch (System.Exception exception_) 
                            {
                                throw new SwaggerException("Could not deserialize the response body.", (int)response_.StatusCode, responseData_, headers_, exception_);
                            }
                        }
                        else
                        if (status_ != "200" && status_ != "204")
                        {
                            var responseData_ = response_.Content == null ? null : await response_.Content.ReadAsStringAsync().ConfigureAwait(false); 
                            throw new SwaggerException("The HTTP status code of the response was not expected (" + (int)response_.StatusCode + ").", (int)response_.StatusCode, responseData_, headers_, null);
                        }
            
                        return default(TokenDTO);
                    }
                    finally
                    {
                        if (response_ != null)
                            response_.Dispose();
                    }
                }
            }
            finally
            {
                if (client_ != null)
                    client_.Dispose();
            }
        }

        /// <exception cref="SwaggerException">A server side error occurred.</exception>
        public System.Threading.Tasks.Task<TokenDTO> RefreshAsync(TokenRefreshDTO dto) 
        {
            return RefreshAsync(dto, System.Threading.CancellationToken.None);
        }

        /// <exception cref="SwaggerException">A server side error occurred.</exception>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        public async System.Threading.Tasks.Task<TokenDTO> RefreshAsync(TokenRefreshDTO dto, System.Threading.CancellationToken cancellationToken) {
            var urlBuilder_ = new System.Text.StringBuilder();
            urlBuilder_.Append(BaseUrl != null ? BaseUrl.TrimEnd('/') : "").Append("/api/token");

            var client_ = new System.Net.Http.HttpClient();
            try {
                using (var request_ = new System.Net.Http.HttpRequestMessage()) {
                    var formDataDictionary = new Dictionary<string, string>()
                    {
                         {"client_id", dto.Client_id },
                         {"grant_type", "refresh_token" },
                         {"refresh_token", dto.Refresh_token }
                    };

                    var formData = new FormUrlEncodedContent(formDataDictionary);
                    var content_ = formData;
                    content_.Headers.ContentType = System.Net.Http.Headers.MediaTypeHeaderValue.Parse("application/x-www-form-urlencoded");
                    request_.Content = content_;
                    request_.Method = new System.Net.Http.HttpMethod("POST");
                    request_.Headers.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                    PrepareRequest(client_, request_, urlBuilder_);
                    var url_ = urlBuilder_.ToString();
                    request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);
                    PrepareRequest(client_, request_, url_);

                    var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                    try {
                        var headers_ = System.Linq.Enumerable.ToDictionary(response_.Headers, h_ => h_.Key, h_ => h_.Value);
                        if (response_.Content != null && response_.Content.Headers != null) {
                            foreach (var item_ in response_.Content.Headers)
                                headers_[item_.Key] = item_.Value;
                        }

                        ProcessResponse(client_, response_);

                        var status_ = ((int)response_.StatusCode).ToString();
                        if (status_ == "200") {
                            var responseData_ = response_.Content == null ? null : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            var result_ = default(TokenDTO);
                            try {
                                result_ = Newtonsoft.Json.JsonConvert.DeserializeObject<TokenDTO>(responseData_, _settings.Value);
                                return result_;
                            } catch (System.Exception exception_) {
                                throw new SwaggerException("Could not deserialize the response body.", (int)response_.StatusCode, responseData_, headers_, exception_);
                            }
                        } else
                        if (status_ != "200" && status_ != "204") {
                            var responseData_ = response_.Content == null ? null : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            throw new SwaggerException("The HTTP status code of the response was not expected (" + (int)response_.StatusCode + ").", (int)response_.StatusCode, responseData_, headers_, null);
                        }

                        return default(TokenDTO);
                    } finally {
                        if (response_ != null)
                            response_.Dispose();
                    }
                }
            } finally {
                if (client_ != null)
                    client_.Dispose();
            }
        }

        private string ConvertToString(object value, System.Globalization.CultureInfo cultureInfo)
        {
            if (value is System.Enum)
            {
                string name = System.Enum.GetName(value.GetType(), value);
                if (name != null)
                {
                    var field = System.Reflection.IntrospectionExtensions.GetTypeInfo(value.GetType()).GetDeclaredField(name);
                    if (field != null)
                    {
                        var attribute = System.Reflection.CustomAttributeExtensions.GetCustomAttribute(field, typeof(System.Runtime.Serialization.EnumMemberAttribute)) 
                            as System.Runtime.Serialization.EnumMemberAttribute;
                        if (attribute != null)
                        {
                            return attribute.Value;
                        }
                    }
                }
            }
            else if (value is byte[])
            {
                return System.Convert.ToBase64String((byte[]) value);
            }
            else if (value != null && value.GetType().IsArray)
            {
                var array = System.Linq.Enumerable.OfType<object>((System.Array) value);
                return string.Join(",", System.Linq.Enumerable.Select(array, o => ConvertToString(o, cultureInfo)));
            }
        
            return System.Convert.ToString(value, cultureInfo);
        }
    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "9.10.72.0 (Newtonsoft.Json v9.0.0.0)")]
    public partial class TokenCreationDTO : System.ComponentModel.INotifyPropertyChanged {
        private string _grant_type;
        private string _username;
        private string _password;
        private string _client_id;

        [Newtonsoft.Json.JsonProperty("grant_type", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Grant_type {
            get { return _grant_type; }
            set {
                if (_grant_type != value) {
                    _grant_type = value;
                    RaisePropertyChanged();
                }
            }
        }

        [Newtonsoft.Json.JsonProperty("username", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Username {
            get { return _username; }
            set {
                if (_username != value) {
                    _username = value;
                    RaisePropertyChanged();
                }
            }
        }

        [Newtonsoft.Json.JsonProperty("password", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Password {
            get { return _password; }
            set {
                if (_password != value) {
                    _password = value;
                    RaisePropertyChanged();
                }
            }
        }

        [Newtonsoft.Json.JsonProperty("client_id", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Client_id {
            get { return _client_id; }
            set {
                if (_client_id != value) {
                    _client_id = value;
                    RaisePropertyChanged();
                }
            }
        }

        public string ToJson() {
            return Newtonsoft.Json.JsonConvert.SerializeObject(this);
        }

        public static TokenCreationDTO FromJson(string data) {
            return Newtonsoft.Json.JsonConvert.DeserializeObject<TokenCreationDTO>(data);
        }

        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;

        protected virtual void RaisePropertyChanged([System.Runtime.CompilerServices.CallerMemberName] string propertyName = null) {
            var handler = PropertyChanged;
            if (handler != null)
                handler(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
        }

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "9.10.72.0 (Newtonsoft.Json v9.0.0.0)")]
    public partial class TokenRefreshDTO : System.ComponentModel.INotifyPropertyChanged
    {
        private string _grant_type;
        private string _client_id;
        private string _refresh_token;

        [Newtonsoft.Json.JsonProperty("grant_type", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Grant_type
        {
            get { return _grant_type; }
            set 
            {
                if (_grant_type != value)
                {
                    _grant_type = value; 
                    RaisePropertyChanged();
                }
            }
        }
    
        [Newtonsoft.Json.JsonProperty("client_id", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Client_id
        {
            get { return _client_id; }
            set 
            {
                if (_client_id != value)
                {
                    _client_id = value; 
                    RaisePropertyChanged();
                }
            }
        }

        [Newtonsoft.Json.JsonProperty("refresh_token", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Refresh_token {
            get { return _refresh_token; }
            set 
            {
                if (_refresh_token != value) 
                {
                    _refresh_token = value;
                    RaisePropertyChanged();
                }
            }
        }

        public string ToJson() 
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(this);
        }
        
        public static TokenRefreshDTO FromJson(string data)
        {
            return Newtonsoft.Json.JsonConvert.DeserializeObject<TokenRefreshDTO>(data);
        }
    
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected virtual void RaisePropertyChanged([System.Runtime.CompilerServices.CallerMemberName] string propertyName = null)
        {
            var handler = PropertyChanged;
            if (handler != null) 
                handler(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
        }    
    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "9.10.72.0 (Newtonsoft.Json v9.0.0.0)")]
    public partial class TokenDTO : System.ComponentModel.INotifyPropertyChanged
    {
        private string _access_token;
        private string _token_type;
        private long _expires_in;
        private string _refresh_token;
    
        [Newtonsoft.Json.JsonProperty("access_token", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Access_token
        {
            get { return _access_token; }
            set 
            {
                if (_access_token != value)
                {
                    _access_token = value; 
                    RaisePropertyChanged();
                }
            }
        }
    
        [Newtonsoft.Json.JsonProperty("token_type", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Token_type
        {
            get { return _token_type; }
            set 
            {
                if (_token_type != value)
                {
                    _token_type = value; 
                    RaisePropertyChanged();
                }
            }
        }
    
        [Newtonsoft.Json.JsonProperty("expires_in", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public long Expires_in
        {
            get { return _expires_in; }
            set 
            {
                if (_expires_in != value)
                {
                    _expires_in = value; 
                    RaisePropertyChanged();
                }
            }
        }

        [Newtonsoft.Json.JsonProperty("refresh_token", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Refresh_token {
            get { return _refresh_token; }
            set {
                if (_refresh_token != value) {
                    _refresh_token = value;
                    RaisePropertyChanged();
                }
            }
        }

        public string ToJson() 
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(this);
        }
        
        public static TokenDTO FromJson(string data)
        {
            return Newtonsoft.Json.JsonConvert.DeserializeObject<TokenDTO>(data);
        }
    
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected virtual void RaisePropertyChanged([System.Runtime.CompilerServices.CallerMemberName] string propertyName = null)
        {
            var handler = PropertyChanged;
            if (handler != null) 
                handler(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
        }
    
    }

    [System.CodeDom.Compiler.GeneratedCode("NSwag", "11.19.0.0 (NJsonSchema v9.10.72.0 (Newtonsoft.Json v9.0.0.0))")]
    public partial class SwaggerException : System.Exception
    {
        public int StatusCode { get; private set; }

        public string Response { get; private set; }

        public System.Collections.Generic.Dictionary<string, System.Collections.Generic.IEnumerable<string>> Headers { get; private set; }

        public SwaggerException(string message, int statusCode, string response, System.Collections.Generic.Dictionary<string, System.Collections.Generic.IEnumerable<string>> headers, System.Exception innerException) 
            : base(message, innerException)
        {
            StatusCode = statusCode;
            Response = response; 
            Headers = headers;
        }

        public override string ToString()
        {
            return string.Format("HTTP Response: \n\n{0}\n\n{1}", Response, base.ToString());
        }
    }

    [System.CodeDom.Compiler.GeneratedCode("NSwag", "11.19.0.0 (NJsonSchema v9.10.72.0 (Newtonsoft.Json v9.0.0.0))")]
    public partial class SwaggerException<TResult> : SwaggerException
    {
        public TResult Result { get; private set; }

        public SwaggerException(string message, int statusCode, string response, System.Collections.Generic.Dictionary<string, System.Collections.Generic.IEnumerable<string>> headers, TResult result, System.Exception innerException) 
            : base(message, statusCode, response, headers, innerException)
        {
            Result = result;
        }
    }

}