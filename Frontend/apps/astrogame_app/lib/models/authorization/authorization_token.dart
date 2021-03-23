import 'package:json_annotation/json_annotation.dart';

part 'authorization_token.g.dart';

@JsonSerializable()
class AuthorizationToken {
  @JsonKey(name: 'access_token')
  String accessToken;

  @JsonKey(name: 'expires_in')
  int expiresIn;

  @JsonKey(name: 'token_type')
  String tokenType;

  @JsonKey(name: 'refresh_token')
  String refreshToken;

  AuthorizationToken(
    this.accessToken,
    this.expiresIn,
    this.tokenType,
    this.refreshToken,
  );

  factory AuthorizationToken.fromJson(Map<String, dynamic> json) =>
      _$AuthorizationTokenFromJson(json);
  Map<String, dynamic> toJson() => _$AuthorizationTokenToJson(this);
}
