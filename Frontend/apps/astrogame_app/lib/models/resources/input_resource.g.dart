// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'input_resource.dart';

// **************************************************************************
// JsonSerializableGenerator
// **************************************************************************

InputResource _$InputResourceFromJson(Map<String, dynamic> json) {
  return InputResource(
    const GuidConverter().fromJson(json['id'] as String),
    const GuidConverter().fromJson(json['resourceId'] as String),
    const GuidConverter().fromJson(json['outputMaterialId'] as String),
    (json['inputValue'] as num)?.toDouble(),
    json['output'] == null
        ? null
        : ResourceManufaction.fromJson(json['output'] as Map<String, dynamic>),
  );
}

Map<String, dynamic> _$InputResourceToJson(InputResource instance) =>
    <String, dynamic>{
      'id': const GuidConverter().toJson(instance.id),
      'resourceId': const GuidConverter().toJson(instance.resourceId),
      'outputMaterialId':
          const GuidConverter().toJson(instance.outputMaterialId),
      'inputValue': instance.inputValue,
      'output': instance.output,
    };
