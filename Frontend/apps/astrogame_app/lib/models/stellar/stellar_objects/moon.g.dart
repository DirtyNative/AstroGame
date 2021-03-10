// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'moon.dart';

// **************************************************************************
// JsonSerializableGenerator
// **************************************************************************

Moon _$MoonFromJson(Map<String, dynamic> json) {
  return Moon(
    const GuidConverter().fromJson(json['id'] as String),
    json['name'] as String,
    const GuidConverter().fromJson(json['parentSystemId'] as String),
    (json['averageDistanceToCenter'] as num)?.toDouble(),
    (json['rotationSpeed'] as num)?.toDouble(),
    json['averageTemperature'] as int,
    json['assetName'] as String,
    (json['scale'] as num)?.toDouble(),
    (json['axialTilt'] as num)?.toDouble(),
    (json['resources'] as List)
        ?.map((e) => e == null
            ? null
            : StellarObjectResource.fromJson(e as Map<String, dynamic>))
        ?.toList(),
    json['order'] as int,
  );
}

Map<String, dynamic> _$MoonToJson(Moon instance) => <String, dynamic>{
      'id': const GuidConverter().toJson(instance.id),
      'name': instance.name,
      'parentSystemId': const GuidConverter().toJson(instance.parentSystemId),
      'averageDistanceToCenter': instance.averageDistanceToCenter,
      'rotationSpeed': instance.rotationSpeed,
      'averageTemperature': instance.averageTemperature,
      'assetName': instance.assetName,
      'scale': instance.scale,
      'axialTilt': instance.axialTilt,
      'resources': instance.resources,
      'order': instance.order,
    };
