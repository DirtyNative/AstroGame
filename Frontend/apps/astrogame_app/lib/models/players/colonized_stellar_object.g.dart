// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'colonized_stellar_object.dart';

// **************************************************************************
// JsonSerializableGenerator
// **************************************************************************

ColonizedStellarObject _$ColonizedStellarObjectFromJson(
    Map<String, dynamic> json) {
  return ColonizedStellarObject()
    ..id = const GuidConverter().fromJson(json['id'] as String)
    ..playerId = const GuidConverter().fromJson(json['playerId'] as String)
    ..colonizedOn = DateTime.parse(json['colonizedOn'] as String)
    ..stellarObjectId =
        const GuidConverter().fromJson(json['stellarObjectId'] as String);
}

Map<String, dynamic> _$ColonizedStellarObjectToJson(
        ColonizedStellarObject instance) =>
    <String, dynamic>{
      'id': const GuidConverter().toJson(instance.id),
      'playerId': const GuidConverter().toJson(instance.playerId),
      'colonizedOn': instance.colonizedOn.toIso8601String(),
      'stellarObjectId': const GuidConverter().toJson(instance.stellarObjectId),
    };
