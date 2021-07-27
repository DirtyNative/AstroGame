import 'package:astrogame_app/configurations/service_locator.dart';
import 'package:astrogame_app/providers/http_header_provider.dart';
import 'package:dio/dio.dart';
import 'package:injectable/injectable.dart';

@lazySingleton
class HeaderInterceptor extends Interceptor {
  late HttpHeaderProvider _httpHeaderProvider;

  HeaderInterceptor() {
    // TODO: Check why this cant be injected
    _httpHeaderProvider = ServiceLocator.get<HttpHeaderProvider>();
  }

  @override
  void onRequest(RequestOptions options, RequestInterceptorHandler handler) {
    var headers = _httpHeaderProvider.getHeaders();

    options.headers.addAll(headers);

    return super.onRequest(options, handler);
  }
}
