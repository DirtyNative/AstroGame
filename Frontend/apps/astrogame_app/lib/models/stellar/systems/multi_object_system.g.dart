// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'multi_object_system.dart';

// **************************************************************************
// JsonSerializableGenerator
// **************************************************************************

MultiObjectSystem _$MultiObjectSystemFromJson(Map<String, dynamic> json) {
  return MultiObjectSystem(
    const GuidConverter().fromJson(json['id'] as String),
    json['name'] as String,
    const GuidConverter().fromJson(json['parentId'] as String),
    json['order'] as int,
  )
    ..parent = const StellarSystemConverter()
        .fromJson(json['parent'] as Map<String, dynamic>)
    ..satellites = (json['satellites'] as List)
        ?.map((e) =>
            const StellarSystemConverter().fromJson(e as Map<String, dynamic>))
        ?.toList()
    ..centerSystems = (json['centerSystems'] as List)
        ?.map((e) =>
            const StellarSystemConverter().fromJson(e as Map<String, dynamic>))
        ?.toList();
}

Map<String, dynamic> _$MultiObjectSystemToJson(MultiObjectSystem instance) =>
    <String, dynamic>{
      'id': const GuidConverter().toJson(instance.id),
      'name': instance.name,
      'parentId': const GuidConverter().toJson(instance.parentId),
      'parent': const StellarSystemConverter().toJson(instance.parent),
      'order': instance.order,
      'satellites': instance.satellites
          ?.map(const StellarSystemConverter().toJson)
          ?.toList(),
      'centerSystems': instance.centerSystems
          ?.map(const StellarSystemConverter().toJson)
          ?.toList(),
    };
