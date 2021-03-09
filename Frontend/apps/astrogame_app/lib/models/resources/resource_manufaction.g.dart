// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'resource_manufaction.dart';

// **************************************************************************
// JsonSerializableGenerator
// **************************************************************************

ResourceManufaction _$ResourceManufactionFromJson(Map<String, dynamic> json) {
  return ResourceManufaction(
    const GuidConverter().fromJson(json['id'] as String),
    const GuidConverter().fromJson(json['outputMaterialId'] as String),
    (json['outputValue'] as num)?.toDouble(),
    json['outputMaterial'] == null
        ? null
        : Material.fromJson(json['outputMaterial'] as Map<String, dynamic>),
    (json['inputResources'] as List)
        ?.map((e) => e == null
            ? null
            : InputResource.fromJson(e as Map<String, dynamic>))
        ?.toList(),
  );
}

Map<String, dynamic> _$ResourceManufactionToJson(
        ResourceManufaction instance) =>
    <String, dynamic>{
      'id': const GuidConverter().toJson(instance.id),
      'outputMaterialId':
          const GuidConverter().toJson(instance.outputMaterialId),
      'outputValue': instance.outputValue,
      'outputMaterial': instance.outputMaterial,
      'inputResources': instance.inputResources,
    };
