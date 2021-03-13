// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'multi_object_system.dart';

// **************************************************************************
// JsonSerializableGenerator
// **************************************************************************

MultiObjectSystem _$MultiObjectSystemFromJson(Map<String, dynamic> json) {
  return MultiObjectSystem()
    ..id = const GuidConverter().fromJson(json['id'] as String)
    ..name = json['name'] as String
    ..parentId = const GuidConverter().fromJson(json['parentId'] as String)
    ..parent = const StellarSystemConverter()
        .fromJson(json['parent'] as Map<String, dynamic>)
    ..order = json['order'] as int
    ..centerObjects = (json['centerObjects'] as List)
        ?.map((e) =>
            const StellarObjectConverter().fromJson(e as Map<String, dynamic>))
        ?.toList()
    ..satellites = (json['satellites'] as List)
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
      'centerObjects': instance.centerObjects
          ?.map(const StellarObjectConverter().toJson)
          ?.toList(),
      'satellites': instance.satellites
          ?.map(const StellarSystemConverter().toJson)
          ?.toList(),
    };
