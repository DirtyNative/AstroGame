import 'package:astrogame_app/configurations/service_locator.dart';
import 'package:astrogame_app/providers/http_header_provider.dart';
import 'package:dio/dio.dart';
import 'package:injectable/injectable.dart';

@lazySingleton
class HeaderInterceptor extends Interceptor {
  HttpHeaderProvider _httpHeaderProvider;

  HeaderInterceptor() {
    _httpHeaderProvider = ServiceLocator.get<HttpHeaderProvider>();
  }

  @override
  Future onRequest(RequestOptions options) {
    var headers = _httpHeaderProvider.getHeaders();

    options.headers.addAll(headers);

    return super.onRequest(options);
  }
}
