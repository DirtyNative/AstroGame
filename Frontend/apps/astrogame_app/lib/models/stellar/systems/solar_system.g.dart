// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'solar_system.dart';

// **************************************************************************
// JsonSerializableGenerator
// **************************************************************************

SolarSystem _$SolarSystemFromJson(Map<String, dynamic> json) {
  return SolarSystem(
    const GuidConverter().fromJson(json['id'] as String),
    json['name'] as String,
    const GuidConverter().fromJson(json['parentId'] as String),
    json['systemNumber'] as int,
    json['isGenerated'] as bool,
  )
    ..parent = const StellarSystemConverter()
        .fromJson(json['parent'] as Map<String, dynamic>)
    ..centerSystems = (json['centerSystems'] as List)
        ?.map((e) =>
            const StellarSystemConverter().fromJson(e as Map<String, dynamic>))
        ?.toList()
    ..satellites = (json['satellites'] as List)
        ?.map((e) =>
            const StellarSystemConverter().fromJson(e as Map<String, dynamic>))
        ?.toList();
}

Map<String, dynamic> _$SolarSystemToJson(SolarSystem instance) =>
    <String, dynamic>{
      'id': const GuidConverter().toJson(instance.id),
      'name': instance.name,
      'parentId': const GuidConverter().toJson(instance.parentId),
      'parent': const StellarSystemConverter().toJson(instance.parent),
      'systemNumber': instance.systemNumber,
      'isGenerated': instance.isGenerated,
      'centerSystems': instance.centerSystems
          ?.map(const StellarSystemConverter().toJson)
          ?.toList(),
      'satellites': instance.satellites
          ?.map(const StellarSystemConverter().toJson)
          ?.toList(),
    };
