// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'authorization_token.dart';

// **************************************************************************
// JsonSerializableGenerator
// **************************************************************************

AuthorizationToken _$AuthorizationTokenFromJson(Map<String, dynamic> json) {
  return AuthorizationToken(
    json['access_token'] as String,
    json['expires_in'] as int,
    json['token_type'] as String,
    json['refresh_token'] as String,
  );
}

Map<String, dynamic> _$AuthorizationTokenToJson(AuthorizationToken instance) =>
    <String, dynamic>{
      'access_token': instance.accessToken,
      'expires_in': instance.expiresIn,
      'token_type': instance.tokenType,
      'refresh_token': instance.refreshToken,
    };
