// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'stellar_object_resource.dart';

// **************************************************************************
// JsonSerializableGenerator
// **************************************************************************

StellarObjectResource _$StellarObjectResourceFromJson(
    Map<String, dynamic> json) {
  return StellarObjectResource(
    const GuidConverter().fromJson(json['id'] as String),
    const GuidConverter().fromJson(json['stellarObjectId'] as String),
    const GuidConverter().fromJson(json['resourceId'] as String),
    (json['multiplier'] as num).toDouble(),
  );
}

Map<String, dynamic> _$StellarObjectResourceToJson(
        StellarObjectResource instance) =>
    <String, dynamic>{
      'id': const GuidConverter().toJson(instance.id),
      'stellarObjectId': const GuidConverter().toJson(instance.stellarObjectId),
      'resourceId': const GuidConverter().toJson(instance.resourceId),
      'multiplier': instance.multiplier,
    };
