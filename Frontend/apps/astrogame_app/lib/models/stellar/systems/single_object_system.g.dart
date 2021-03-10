// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'single_object_system.dart';

// **************************************************************************
// JsonSerializableGenerator
// **************************************************************************

SingleObjectSystem _$SingleObjectSystemFromJson(Map<String, dynamic> json) {
  return SingleObjectSystem(
    const GuidConverter().fromJson(json['id'] as String),
    json['name'] as String,
    const GuidConverter().fromJson(json['parentId'] as String),
    json['order'] as int,
    const GuidConverter().fromJson(json['centerObjectId'] as String),
  )
    ..parent = const StellarSystemConverter()
        .fromJson(json['parent'] as Map<String, dynamic>)
    ..satellites = (json['satellites'] as List)
        ?.map((e) =>
            const StellarSystemConverter().fromJson(e as Map<String, dynamic>))
        ?.toList()
    ..centerObject = const StellarObjectConverter()
        .fromJson(json['centerObject'] as Map<String, dynamic>);
}

Map<String, dynamic> _$SingleObjectSystemToJson(SingleObjectSystem instance) =>
    <String, dynamic>{
      'id': const GuidConverter().toJson(instance.id),
      'name': instance.name,
      'parentId': const GuidConverter().toJson(instance.parentId),
      'parent': const StellarSystemConverter().toJson(instance.parent),
      'order': instance.order,
      'satellites': instance.satellites
          ?.map(const StellarSystemConverter().toJson)
          ?.toList(),
      'centerObject':
          const StellarObjectConverter().toJson(instance.centerObject),
      'centerObjectId': const GuidConverter().toJson(instance.centerObjectId),
    };
